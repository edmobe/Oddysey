package com.src.dataStructs;
public class BNode
{
	static int order;  
	int count; 
	int key[];  
	BNode child[]; 
	boolean leaf; 
	BNode parent;  


	public BNode(int order, BNode parent)
	{
		this.order = order; 
		this.parent = parent; 
		key = new int[2*order - 1];  
		child = new BNode[2*order]; 
		leaf = true; 
		count = 0;
	}


	public int getValue(int index)
	{
		return key[index];
	}


	public BNode getChild(int index)
	{
		return child[index];
	}


}