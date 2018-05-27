package com.src.dataStructs;


public class AVLTree {

	private AVLNode root;
	
	


	public AVLTree() {
		this.root = null;
	}
	
	public void insert(String data) {
		
		AVLNode newNode = new AVLNode(data);
		
		if(this.root == null) {
			this.root = newNode;
		}else {
			
			root = insertAVL(newNode, root);
		}
	}
	
	public AVLNode insertAVL(AVLNode newNode, AVLNode subtree) {
		
		AVLNode newN = subtree;
		
		
		//insert the node in the left subtree
		if(newNode.data.compareTo(subtree.data) < 0) { //si el nuevo nodo es menor al actual, debe tirar un 1
			
			if(subtree.leftNode == null) {
				subtree.leftNode = newNode;
					
			}else {
				
				subtree.leftNode = insertAVL(newNode, subtree.leftNode);
				
				//implements the left rotation
				if (getFe(subtree.leftNode) - getFe(subtree.rightNode) == 2) {
					if(newNode.data.compareTo(subtree.leftNode.data) < 0) { //si el nuevo nodo es menor al nodo izq del actual, debe tirar un 1
						newN = leftrotation(subtree);
					}else {
						newN = leftDoubleRot(subtree);
						
					}}}}
		
		//insert the node in the right subtree
		else if(newNode.data.compareTo(subtree.data) > 0) { // si el nuevo nodo es mayor al actual, debe tirar un -1
			
			if (subtree.rightNode == null) {
				subtree.rightNode = newNode;
			}else {
				subtree.rightNode = insertAVL(newNode, subtree.rightNode);
				
				//implements the right rotation
				if (getFe(subtree.rightNode) - getFe(subtree.leftNode) == 2) {
					if(newNode.data.compareTo(subtree.rightNode.data) > 0) {
						newN = rightrotation(subtree);
					}else {
						newN = rightDoubleRot(subtree);
					}}}}
		
		//Duplicate node
		else {
			//SE MUESTRA UN MENSAJE SI EL NODO ESTA PUBLICADO?
		}
		
		// Refresh de height of the AVLTree
		
		if (subtree.leftNode == null && subtree.rightNode != null) {
			
			subtree.fe = subtree.rightNode.fe+1;
			
		}else if  (subtree.rightNode == null && subtree.leftNode != null) {
			
			subtree.fe = subtree.leftNode.fe+1;
		}else {
			subtree.fe = Math.max(getFe(subtree.leftNode), getFe(subtree.rightNode));
		}
		
		return newN;
	}
	
	
	public AVLNode search(String d) {
		return searchAVL(d, this.root);
	}
	
	private AVLNode searchAVL(String d, AVLNode node) {
		
		if (this.root == null) {
			return null;
		}else if(node.data.compareTo(d) == 0) {
			return node;
		}else if(node.data.compareTo(d) < 0) { //si el dato es menor al buscado, debe ser mayor a 0
			return searchAVL(d, node.rightNode);
		}else {
			return searchAVL(d, node.leftNode);
		}
	}
	
	
	// Simple left rotation
	
	public AVLNode leftrotation(AVLNode node) {
		
		AVLNode aux = node.leftNode;
		node.leftNode = aux.rightNode;
		aux.rightNode = node;
		node.fe = Math.max(getFe(node.leftNode), getFe(node.rightNode))+1;
		aux.fe = Math.max(getFe(aux.leftNode), getFe(aux.rightNode))+1;
		return aux;
	}
	
	
	//Simple rigth rotation
	
	public AVLNode rightrotation(AVLNode node) {
		
		AVLNode aux = node.rightNode;
		node.rightNode = aux.leftNode;
		aux.leftNode = node;
		node.fe = Math.max(getFe(node.leftNode), getFe(node.rightNode))+1;
		aux.fe = Math.max(getFe(aux.leftNode), getFe(aux.rightNode))+1;
		return aux;
	}
	
	// Double left rotation
	
	public AVLNode leftDoubleRot(AVLNode node) {
		
		AVLNode aux;
		node.leftNode = rightrotation(node.leftNode);
		aux = leftrotation(node);
		return aux;
	}
	
	// Double rigth rotation
	
	public AVLNode rightDoubleRot(AVLNode node) {
			
		AVLNode aux;
		node.rightNode = leftrotation(node.leftNode);
		aux = rightrotation(node);
		return aux;
	}
	
	public void delete(AVLNode node) {
	}
		
	
	//Getters and Setters
	public AVLNode getRoot() {
		return root;
	}
	
	
	public int getFe(AVLNode node) {
		if (node == null) {
			return -1;
		}else {
			return node.fe;
		}
	}
	
	
}	