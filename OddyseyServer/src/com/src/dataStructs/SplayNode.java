package com.src.dataStructs;

public class SplayNode<Key extends Comparable<Key>, Value> {

	Key key;
	Value data;
	SplayNode left;
	SplayNode right;
	//private Audiofile audio;
	
	public SplayNode(Key key, Value data) {
		this.key = key;
		this.data = data;
	}
	
}
