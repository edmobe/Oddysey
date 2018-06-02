package com.src.dataStructs;

import com.src.audio.AudioFile;

public class SplayTree<Key extends Comparable<Key>, Value> {
	
	private SplayNode root;
	
	
	
	public boolean contains(Key key) {
		return get(key) != null;
	}
	
	public Value get(Key key) {
		
		root = splay(root,key);
		int c = key.compareTo((Key) root.key);
		if (c == 0) {
			return (Value) root.data;
		}else {
			return null;
		}
	}
	
	
	public void insert(Key key, Value data) {
		
		if (root == null) {
			root = new SplayNode(key,data);
			return;
		}
		
		root = splay(root, key);
		
		int c = key.compareTo((Key) root.key);
		
		if (c < 0) {
			SplayNode current = new SplayNode(key, data);
			current.left = root.left;
			current.right = root;
			root.left = null;
			root = current;
		}else if (c > 0) {
			SplayNode current = new SplayNode(key, data);
			current.right = root.right;
			current.left = root;
			root.right = null;
			root = current;
			
		}else {
			root.data = data;
		}
	}
	
	public void delete(Key key) {
		
		if (root == null) {
			return;
		}
		
		root = splay(root, key);
		
		int c = key.compareTo((Key) root.key);
		
		if (c == 0) {
			
			if (root.left == null) {
				root = root.right;	
			} else {
				SplayNode temp = root.right;
				root = root.left;
				splay(root, key);
				root.right = temp;
			}
		}
	}
	
	private SplayNode splay(SplayNode sn, Key key) {
		
		if (sn == null) 
			return null;

        int cmp1 = key.compareTo((Key) sn.key);

        if (cmp1 < 0) {
            // key not in tree, so we're done
            if (sn.left == null) {
                return sn;
            }
            int cmp2 = key.compareTo((Key) sn.left.key);
            if (cmp2 < 0) {
                sn.left.left = splay(sn.left.left, key);
                sn = rotateRight(sn);
            }
            else if (cmp2 > 0) {
                sn.left.right = splay(sn.left.right, key);
                if (sn.left.right != null)
                    sn.left = rotateLeft(sn.left);
            }
            
            if (sn.left == null) return sn;
            else                return rotateRight(sn);
        }

        else if (cmp1 > 0) { 
            // key not in tree, so we're done
            if (sn.right == null) {
                return sn;
            }

            int cmp2 = key.compareTo((Key) sn.right.key);
            if (cmp2 < 0) {
                sn.right.left  = splay(sn.right.left, key);
                if (sn.right.left != null)
                    sn.right = rotateRight(sn.right);
            }
            else if (cmp2 > 0) {
                sn.right.right = splay(sn.right.right, key);
                sn = rotateLeft(sn);
            }
            
            if (sn.right == null) return sn;
            else                 return rotateLeft(sn);
        }

        else return sn;
		
	}

	 private SplayNode rotateRight(SplayNode current) {
	        SplayNode temp = current.left;
	        current.left = temp.right;
	        temp.right = current;
	        return temp;
	    }

	
	    private SplayNode rotateLeft(SplayNode current) {
	        SplayNode temp = current.right;
	        current.right = temp.left;
	        temp.left = current;
	        return temp;
	    }
}
