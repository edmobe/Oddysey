package com.src.login;

import java.io.IOException;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.src.main.MainClass;

public class LogInManager extends MainClass {

	private final String opcode = "001";

	public void addUser() throws JsonGenerationException, JsonMappingException, IOException {

		// Se le pide los datos al usuario en la interfaz grafica para rellenar los
		// campos del constructor User
		// Se verifica que el usuario sea unico y luego se crea el user
		// hay que entrar en el this.getUsers() y revisar todos los nickmanes para
		// buscar equivalentes
		
		

	}

	public boolean Login(User u, String pass) {
		return true;
	}

	// Getters and setters
	public String getOpCode() {
		return this.opcode;
	}

}
