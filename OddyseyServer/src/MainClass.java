import java.io.IOException;

public class MainClass {

	public static void main(String[] args) {

		Server s1 = new Server();
		try {
			s1.receive();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
