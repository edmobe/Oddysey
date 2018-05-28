package com.src.server;

import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementWrapper;
import javax.xml.bind.annotation.XmlRootElement;

import com.src.audio.AudioFile;

@XmlRootElement(name = "OperationData")
public class OperationData {
	@XmlElementWrapper(name = "AudioFiles")
	@XmlElement(name = "AudioFile")
	public List<AudioFile> audioFiles;
	@XmlElement(name = "SongToAdd")
	public AudioFile songToAdd;
	@XmlElement(name = "NameToDel")
	public String nameToDel;
	@XmlElement(name = "AuthorToDel")
	public String authorToDel;
	@XmlElement(name = "SongData")
	public String songData;
	
	public OperationData() {
		audioFiles = new ArrayList<AudioFile>();
	}
	
}
