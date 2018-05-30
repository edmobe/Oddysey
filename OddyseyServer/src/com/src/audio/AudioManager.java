package com.src.audio;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringWriter;
import java.io.Writer;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Collection;
import java.util.LinkedList;
import java.util.List;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectWriter;
import com.fasterxml.jackson.databind.SerializationFeature;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.google.gson.stream.JsonReader;
import com.src.main.MainClass;
import com.src.server.OperationData;
import com.src.server.XmlMessage;

import org.jmusixmatch.MusixMatch;
import org.jmusixmatch.MusixMatchException;
import org.jmusixmatch.entity.track.Track;
import org.jmusixmatch.entity.track.TrackData;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.json.XML;

public class AudioManager {

	// private FileWriter fl;
	public static List<AudioFile> songs;
	/*
	// Falta hacer que funcionen con AudioFiles
	private static AVLTree byArtist;
	private static BTree byName;
	private static SplayTree byLyrics;
	 */
	
	public AudioManager() {
		// Hacer que el JSON agregue las canciones a songs
		songs = new ArrayList<AudioFile>();
		parseAudiosFile();
		/*
		// Falta hacer que funcionen con AudioFiles
		byArtist = new AVLTree();
		byName = new BTree();
		byLyrics = new SplayTree();
		 */
	}
	
	private void parseAudiosFile() {
		Type REVIEW_TYPE = new TypeToken<List<AudioFile>>(){}.getType();
		Gson gson = new Gson();
		JsonReader reader;
		try {
			FileReader fileReader = new FileReader("jsonFiles/audios.json");
			reader = new JsonReader(fileReader);
			List<AudioFile> jsonSongs = gson.fromJson(reader, REVIEW_TYPE); // contains the whole reviews list
			if(jsonSongs != null) {
				songs = jsonSongs;
			}
			reader.close();
			fileReader.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public List<AudioFile> getSongList() {
		return songs;
	}
	
	public AudioFile getSong(String name, String author) {
		for (int i = 0; i < songs.size(); i++) {
			AudioFile song = songs.get(i);
			if(song.name.equals(name) && song.author.equals(author)) {
				return song;
			}
		}
		return null;
	}
	
	/**
	 * Adds an {@code AudioFile} to the list of songs
	 * @param audio {@code AudioFile} object (song)
	 * @return {@code false} if the song already is in the song list. Otherwise, returns {@code true}
	 * @throws IOException 
	 */
	public boolean addSong(AudioFile audio) throws IOException {
		if (getSong(audio.name, audio.author) == null) {
			songs.add(audio);
			return true;
		}
		return false;
	}
	
	public boolean deleteSong(AudioFile audio) throws IOException {
		songs.remove(audio);
		return true;
	} 
	
	
	public void updateSongsFile() {
		String json = new Gson().toJson(songs);
		try {
			File audiosFile = new File("jsonFiles/audios.json");
			FileWriter writer = new FileWriter(audiosFile, false);
			writer.write(json);
			writer.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public String getAllSongsXmlString() {
		XmlMessage xml = new XmlMessage();
		OperationData opData = xml.operationData;
		for (int i = 0; i < songs.size(); i++) {
			opData.audioFiles.add(songs.get(i));
		}
		return xml.getXmlString();
	}
	
	public String getSongsMainDataXmlString() {
		XmlMessage xml = new XmlMessage();
		OperationData opData = xml.operationData;
		for (int i = 0; i < songs.size(); i++) {
			AudioFile song = getSongCopy(i);
			song.data = null; // this reduces the song size considerably
			opData.audioFiles.add(song);
		}
		return xml.getXmlString();
	}

	private AudioFile getSongCopy(int position) {
		AudioFile copy = new AudioFile();
		AudioFile original = songs.get(position);
		
		copy.about = original.about;
		copy.album = original.album;
		copy.author = original.author;
		copy.data = original.data;
		copy.lyrics = original.lyrics;
		copy.name = original.name;
		copy.score = original.score;
		copy.year = original.year;
		copy.length = original.length;
		return copy;
	}
	
	private AudioFile getSongCopyWithoutData(AudioFile audio) {
		for (int i = 0; i < songs.size(); i++) {
			if (audio.equals(songs.get(i))) {
				AudioFile copy = getSongCopy(i);
				copy.data = null;
				return copy;
			}
		}
		return null;
	}

	public String getSongDataXmlString(String opCodeMessage) {
		String[] data = opCodeMessage.split("-!%!-");
		return getSong(data[0], data[1]).data;
	}
	
	public String getUpdatedSongDataXmlString(String opCodeMessage) {
		String[] data = opCodeMessage.split("-!%!-");
		AudioFile audioToUpdate = getSong(data[0], data[1]);
		updateMetadata(audioToUpdate);
		AudioFile toSend = getSongCopyWithoutData(audioToUpdate);
		XmlMessage message = new XmlMessage();
		message.operationData.songToUpdate = audioToUpdate;
		return message.getXmlString();
	}
	
	public void updateMetadata(AudioFile audio) {
		String musixMatchKey = "0f3a24470422fadf7054c6ff84f5ff4d";
		String lastFmKey = "ff3f5b0c93edf76b85c985489046e537";
		MusixMatch musixMatch = new MusixMatch(musixMatchKey);		
		try {
			Track track = musixMatch.getMatchingTrack(audio.name, audio.author);
			TrackData data = track.getTrack();
			String about = de.umass.lastfm.Track.getInfo(audio.author, audio.name, lastFmKey).getWikiText();
			String lyrics = musixMatch.getLyrics(data.getTrackId()).getLyricsBody();
			
			audio.album = data.getAlbumName();
			audio.about = about;
			audio.year = data.getFirstReleaseDate().replaceAll("T00:00:00Z", "");
			
			if (!lyrics.equals("")) {
				audio.lyrics = lyrics;
			}
			
			// For debugging
			System.out.println("Album Name : " + data.getAlbumName());
			System.out.println("");
			System.out.println("Album Name : " + data.getArtistName());
			System.out.println("");
			System.out.println("About: " + about);
			System.out.println("");
			System.out.println("Lyrics: " + musixMatch.getLyrics(data.getTrackId()).getLyricsBody());
			
		} catch (MusixMatchException e) {
			// For debugging
			System.out.println("Song not found");
		}
		
	}
	
	/*
	public void addAudio(String b) throws JsonGenerationException, JsonMappingException, IOException {
		try {
			JSONObject xml = XML.toJSONObject(b);
			String xmlData = xml.toString(4);
			fl = new FileWriter(this.getAudios(), true);
			fl.write(xmlData);
			
		}catch(JSONException je) {
            System.out.println(je.toString());
        }
		
	*/
		
		/* GUARDA EN EL JSON
		this.getMapper().
		writerWithDefaultPrettyPrinter().
		writeValue(this.getAudios(), b);

		// GUARDAR LA CANCION EN LA CARPETA
	}

	public void deleteAudio(AudioFile s) {

	}

	public void synchronizemetadata(AudioFile s) {

	}

	// metodo que agrega los buffers
	*/
}
