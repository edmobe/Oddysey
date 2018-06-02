package com.src.login;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.google.gson.stream.JsonReader;
import com.src.audio.AudioFile;

public class UserManager {

	// private FileWriter fl;
	public static List<User> users;
	/*
	// Falta hacer que funcionen con AudioFiles
	private static AVLTree byArtist;
	private static BTree byName;
	private static SplayTree byLyrics;
	 */
	
	public UserManager() {
		// Hacer que el JSON agregue las canciones a songs
		users = new ArrayList<User>();
		parseUserFile();
		
	}
	
	private void parseUserFile() {
		Type REVIEW_TYPE = new TypeToken<List<User>>(){}.getType();
		Gson gson = new Gson();
		JsonReader reader;
		try {
			FileReader fileReader = new FileReader("jsonFiles/users.json");
			reader = new JsonReader(fileReader);
			List<User> jsonUsers = gson.fromJson(reader, REVIEW_TYPE); // contains the whole reviews list
			if(jsonUsers != null) {
				users = jsonUsers;
			}
			reader.close();
			fileReader.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public List<User> getUserList() {
		return users;
	}
	
	public User getUser(String nickname) {
		for (int i = 0; i < users.size(); i++) {
			User user = users.get(i);
			if(user.nickname.equals(nickname)) {
				return user;
			}
		}
		return null;
	}
	public boolean checkUser(User user) {
		if (users.isEmpty())
			return false;
		for (int i = 0; i < users.size(); i++) {
			User temp = users.get(i);
			//System.out.println(user.nickname);Debbuging
			if(user.nickname.equals(temp.nickname) && user.password.equals(temp.password)) {
				return true;
			}
					
			
		}return false;
		
	}
	public User getUserLog(String nickname, String password) {
		for (int i = 0; i < users.size(); i++) {
			User user = users.get(i);
			if(user.nickname.equals(nickname) && user.password.equals(password)) {
				return user;
			}
		}
		return null;
	}
	
	/**
	 * Adds an {@code User} to the list of users
	 * @param user {@code User} object (user)
	 * @return {@code false} if the user already is in the user list. Otherwise, returns {@code true}
	 * @throws IOException 
	 */
	public boolean addUser(User user) throws IOException {
		if (getUser(user.nickname) == null) {
			users.add(user);
			return true;
		}
		return false;
	}
	
	public boolean deleteUser(User user) throws IOException {
		users.remove(user);
		return true;
	} 
	public void updateUsersFile() {
		String json = new Gson().toJson(users);
		try {
			File usersFile = new File("jsonFiles/users.json");
			FileWriter writer = new FileWriter(usersFile, false);
			writer.write(json);
			writer.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
