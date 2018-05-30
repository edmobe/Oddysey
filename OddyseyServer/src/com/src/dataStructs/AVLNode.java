package com.src.dataStructs;

import com.src.audio.AudioFile;

public class AVLNode {
	
	String data;
	int fe;
	AVLNode leftNode;
	AVLNode rightNode;
	AudioFile audio;
	
	
	public AVLNode(String data) {
		this.data = data;
		this.fe = 0;
		this.leftNode = null;
		this.rightNode = null;
	}
	

	

}
