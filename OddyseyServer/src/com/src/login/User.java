package com.src.login;

//Esta clase lleva los usuarios
public class User {

	private String nickname;
	private String name;
	private String lastname;
	private String age;
	private String favorites; // Como accedo a esta informacion a la hora de que la app me recomiende
								// canciones?
	private String password;
	private String friends; // Como accedo a los amigos a la hora de que se vayan a ocupar para algo? xDD

	// Constructor
	public User(String nickname, String name, String lastname, String age, String favorites, String password,
			String friends) {

		this.nickname = nickname;
		this.name = name;
		this.lastname = lastname;
		this.age = age;
		this.favorites = favorites;
		this.password = password;
		this.friends = friends;
	}

	// Getters and setters
	public String getNickname() {
		return nickname;
	}

	public void setNickname(String nickname) {
		// AQUI SE REALIZA LA VERIFICACION DE SI YA EXISTE O NO ESE NICKNAME
		this.nickname = nickname;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getLastname() {
		return lastname;
	}

	public void setLastname(String lastname) {
		this.lastname = lastname;
	}

	public String getAge() {
		return age;
	}

	public void setAge(String age) {
		this.age = age;
	}

	public String getFavorites() {
		return favorites;
	}

	public void setFavorites(String favorites) {
		this.favorites = favorites;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getFriends() {
		return friends;
	}

	public void setFriends(String friends) {
		this.friends = friends;
	}

}
