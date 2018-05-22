package com.src.server;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

import com.src.audio.AudioFile;

@XmlRootElement(name = "OpData")
public class OperationData {
	@XmlElement(name = "Audio")
	public AudioFile audio;
	@XmlElement(name = "NameToDel")
	public String nameToDel;
	@XmlElement(name = "AuthorToDel")
	public String authorToDel;
	
	@Override
	public String toString() {
		return audio.toString() + "/" + nameToDel + "/" + authorToDel;
	}
}
