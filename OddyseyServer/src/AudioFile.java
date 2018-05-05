
//Estas son las canciones
public class AudioFile {
	
	// private tipodedatoquealmacenabytes bytes;
	private String name;
	private String author;
	private String album;
	private String year;
	private String lyrics;
	private String time; // String??
	private int score = 0;
	
	
	// Constructor
	public AudioFile(String name, String author, String album, String year, String lyrics, String time) {
		this.name = name;
		this.author = author;
		this.album = album;
		this.year = year;
		this.lyrics = lyrics;
		this.time = time;
	
	}
	
	
	// Getters and Setters
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getAuthor() {
		return author;
	}
	public void setAuthor(String author) {
		this.author = author;
	}
	public String getAlbum() {
		return album;
	}
	public void setAlbum(String album) {
		this.album = album;
	}
	public String getYear() {
		return year;
	}
	public void setYear(String year) {
		this.year = year;
	}
	public String getLyrics() {
		return lyrics;
	}
	public void setLyrics(String lyrics) {
		this.lyrics = lyrics;
	}
	public String getTime() {
		return time;
	}
	public void setTime(String time) {
		this.time = time;
	}
	public int getScore() {
		return score;
	}
	public void setScore(int score) {
		this.score = score;
	}


}
