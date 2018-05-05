


import java.io.IOException;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;

public class LogInManager extends MainClass{
	
	
	
	
	
	
	private final String opcode = "001";
	
	public void addUser() throws JsonGenerationException, JsonMappingException, IOException {
		
		//Se le pide los datos al usuario en la interfaz grafica para rellenar los campos del constructor User
		//Se verifica que el usuario sea unico y luego se crea el user
		// hay que entrar en el this.getUsers() y revisar todos los nickmanes para buscar equivalentes
		User newuser = new User("Allack","Josue","Mata","21", "Metal,Rock","123456789","Banners, Ed");
		this.getMapper()
			.writerWithDefaultPrettyPrinter()
			.writeValue(this.getUsers(), newuser);
		
	
	} public boolean Login(User u, String pass) {
		return true;
	}

	//Getters and setters
	public String getOpCode() {
		return this.opcode;
	}

}

