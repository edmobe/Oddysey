package com.src.login;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

//Esta clase lleva los usuarios
@XmlRootElement(name = "User")
public class User {
	@XmlElement(name = "Name")
	public String name;
	@XmlElement(name = "LastName")
	public String lastname;
	@XmlElement(name = "NickName")
	public String nickname;
	@XmlElement(name = "Password")
	public String password;
	@XmlElement(name = "Age")
	public String age;
	@XmlElement(name = "Favorites")
	public String favorites; // Como accedo a esta informacion a la hora de que la app me recomiende
	@XmlElement(name = "Friends")
	public String friends; // Como accedo a los amigos a la hora de que se vayan a ocupar para algo? xDD

	// Constructor
	public User() {
		
	}
	public void setMainParameters(String nickname, String name, String lastname, String age, String favorites, String password,
			String friends) {

		this.nickname = nickname;
		this.name = name;
		this.lastname = lastname;
		this.age = age;
		this.favorites = favorites;
		this.password = password;
		this.friends = friends;
	}

}