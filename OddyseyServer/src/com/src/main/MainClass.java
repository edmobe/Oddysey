package com.src.main;

import java.io.File;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.src.audio.AudioManager;
import com.src.login.LogInManager;
import com.src.server.Server;

public class MainClass {

	public static void main(String[] args) { // pruebas

		System.out.println("Hello world");
		
		Server s1 = new Server();
		s1.run();

	}

}
