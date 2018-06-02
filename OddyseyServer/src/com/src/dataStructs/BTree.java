package com.src.dataStructs;

public class BTree {



	static int order; 

	BNode root; 



	public BTree(int order)
	{
		this.order = order;

		root = new BNode(order, null);

	}



	public BNode search(BNode root, int key)
	{
		int i = 0;

		while(i < root.count && key > root.key[i])
		{
			i++;
		}

		if(i <= root.count && key == root.key[i])
		{
			return root;
		}

		if(root.leaf)
        {
			return null ;

		}
		else
		{

			return search(root.getChild(i),key);

		}
	}

	public void split(BNode current, int i, BNode current2)
	{
		BNode temp = new BNode(order,null);

		temp.leaf = current2.leaf;

		temp.count = order - 1;

		for(int j = 0; j < order - 1; j++)
		{
			temp.key[j] = current2.key[j+order]; 

		}
		if(!current2.leaf)
		{
			for(int k = 0; k < order; k++)
			{
				temp.child[k] = current2.child[k+order]; 
			}
		}

		current2.count = order - 1; 

		for(int j = current.count ; j> i ; j--)
		{				 

			current.child[j+1] = current.child[j]; 

		}
		current.child[i+1] = temp; 

		for(int j = current.count; j> i; j--)
		{
			current.key[j + 1] = current.key[j]; 
		}
		current.key[i] = current2.key[order-1];

		current2.key[order-1 ] = 0; 

		for(int j = 0; j < order - 1; j++)
		{
			current2.key[j + order] = 0;
		}



		current.count ++; 
	}


	public void nonfullInsert(BNode current, int key)
	{
		int i = current.count; 

		if(current.leaf)
		{
			while(i >= 1 && key < current.key[i-1])
			{
				current.key[i] = current.key[i-1];

				i--;
			}

			current.key[i] = key;
			current.count ++; 

		}


		else
		{
			int j = 0;
			while(j < current.count  && key > current.key[j])
			{			            		
				j++;
			}

		

			if(current.child[j].count == order*2 - 1)
			{
				split(current,j,current.child[j]);

				if(key > current.key[j])
				{
					j++;
				}
			}

			nonfullInsert(current.child[j],key);
		}
	}


	public void insert(BTree t, int key)
	{
		BNode r = t.root;
		
		if(r.count == 2*order - 1)
		{
			BNode s = new BNode(order,null);

			t.root = s;    
			s.leaf = false;   
			s.count = 0;   		       
			s.child[0] = r;

			split(s,0,r);

			nonfullInsert(s, key); 
		}
		else
			nonfullInsert(r,key);
	}
	
}