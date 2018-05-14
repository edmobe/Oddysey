
import java.io.File;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.src.server.Server;

public class MainClass {

	private final ObjectMapper mapper = new ObjectMapper();
	private static LogInManager lim = new LogInManager();
	private static AudioManager am = new AudioManager();
	private final File users = new File("jsonFiles/users.json");
	private final File audios = new File("jsonFiles/audios.json");

	public static void main(String[] args) { // pruebas

		System.out.println("Hello world");
		
		Server s1 = new Server();
		s1.run();

	}

	// Getters
	public LogInManager getAU() {
		return lim;
	}

	public AudioManager getAM() {
		return am;
	}

	public ObjectMapper getMapper() {
		return mapper;
	}

	public File getUsers() {
		return users;
	}

	public File getAudios() {
		return audios;
	}

}
