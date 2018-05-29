package com.src.audio;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

//Estas son las canciones
@XmlRootElement(name = "AudioFile")
public class AudioFile {

	@XmlElement(name = "Name")
	public String name;
	@XmlElement(name = "Author")
	public String author;
	@XmlElement(name = "Album")
	public String album;
	@XmlElement(name = "Year")
	public String year;
	@XmlElement(name = "Lyrics")
	public String lyrics;
	@XmlElement(name = "Length")
	public String length;
	@XmlElement(name = "Score")
	public String score;
	@XmlElement(name = "Data")
	public String data;
	@XmlElement(name = "About")
	public String about;
	
	public AudioFile() {
		
	}
	
	public void SetMainParameters(String name, String author, String album, String score)
    {
        this.name = name;
        this.author = author;
        this.album = album;
        this.score = score;
    }
	
	//For debugging
	@Override
	public String toString() {
		return name + "/" + author + "/" + album + "/" + year + "/" + lyrics + "/" + length + "/" + score;
	}
	
	
	
	
}
