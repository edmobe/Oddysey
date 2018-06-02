package com.src.server;


import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.StringReader;
import java.io.UnsupportedEncodingException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.List;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.src.audio.AudioFile;
import com.src.audio.AudioManager;
import com.src.dataStructs.AVLTree;
import com.src.dataStructs.SplayTree;
import com.src.login.User;
import com.src.login.UserManager;


/**
 * Apps server
 * 
 * @author edmobe
 *
 */
public class Server extends Thread {
	
	private static String opCode;
	private static String opCodeMessage;
	private final ObjectMapper mapper;
	//private static LogInManager lim;
	private static AudioManager audioManager;
	private static UserManager userManager;
	private AVLTree avltree;
	SplayTree<Integer, String> splaytree = new SplayTree<Integer, String>();
	private int splaykey = 1;
	private int bkey = 1;
	
	public Server() {
		mapper = new ObjectMapper();
		// lim = new LogInManager();
		audioManager = new AudioManager();
		userManager = new UserManager();
		avltree = new AVLTree();
		
		
	}
	
	/**
	 * Runs the Socket loop.
	 */
	@Override
	public void run() {
		
		try {
			@SuppressWarnings("resource")
			ServerSocket serverSocket = new ServerSocket(6000, 10); // INVESTIGAR SIGNIFICADO DE BACKLOG
			
			while (true) {				
				Socket socket = serverSocket.accept();
				InputStream is = socket.getInputStream();
				OutputStream os = socket.getOutputStream();
				
				// Getting OPCode
		        ByteArrayOutputStream buffer = new ByteArrayOutputStream();
		        int nRead;
		        byte[] data = new byte[100];
		        while ((nRead = is.read(data, 0, data.length)) != -1) {
			          buffer.write(data, 0, nRead);
		        }
		        String message = buffer.toString("UTF-8");
		        String[] firstMessage = message.split("/");
		        opCode = firstMessage[0];
		        opCodeMessage = firstMessage[1]; // Message attached to the OPCode (needs reply)
		        
		       // System.out.println("OPCode: " + opCode + ". First message: " + opCodeMessage);
		        
		        
		        // Re-open (literally the one and only way I found to make this work)
		        socket = serverSocket.accept();
		        is = socket.getInputStream();
		        os = socket.getOutputStream();
		        
		        // Sending message based on OPCode
		        reply(os, opCode, opCodeMessage);	

		        // Getting message
		        buffer = new ByteArrayOutputStream();
		        data = new byte[16384];
		        while ((nRead = is.read(data, 0, data.length)) != -1) {
		          buffer.write(data, 0, nRead);
		        }

		       // String received = buffer.toString("UTF-8"); // Message for server usage (does not need reply)
		        
		        receive(buffer, opCode);		       
		        
				socket.close();				
			}
			
		} catch (IOException | JAXBException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * Sends a reply based on the opCode
	 * @param os {@code OutputStram}
	 * @param opCode operation code
	 * @throws UnsupportedEncodingException
	 * @throws IOException
	 */
	private void reply(OutputStream os, String opCode, String opCodeMessage) throws UnsupportedEncodingException, IOException {
		String toSend = "OPCode not defined";
		if (opCode.equals("001")) { // Add song
			toSend = "Got the OPCode " + opCode + " (add song).";
		} else if (opCode.equals("002")) { // Send list of songs
			toSend = audioManager.getSongsMainDataXmlString();
		} else if (opCode.equals("003")) { // Send the song data
			toSend = audioManager.getSongDataXmlString(opCodeMessage);
		} else if (opCode.equals("004")) { // Delete song
			toSend = "Got the OPCode " + opCode + " (delete song).";
		} else if (opCode.equals("005")) { // Get song metadata online
			toSend = audioManager.getUpdatedSongDataXmlString(opCodeMessage);
		} else if (opCode.equals("006")) {
			if (opCodeMessage.equals("Registered")) {
				//Envia el mensaje de que se registro con exito
			}else if (opCodeMessage.equals("Username Already in use")) {
				//Envia el Mensaje de que el username esta en uso
			}
			
		}
		os.write(toSend.getBytes("UTF-8"));
	}
	
	/**
	 * Decides which operation to with the received input based on the operation code.
	 * @param buffer input {@code String}
	 * @param opCode operation code
	 * @throws JAXBException
	 * @throws IOException 
	 * @throws JsonMappingException 
	 * @throws JsonGenerationException 
	 */
	private void receive(ByteArrayOutputStream buffer, String opCode) throws JAXBException, JsonGenerationException, JsonMappingException, IOException {
		
		if (opCode.equals("001")) { // Add song		
			String xmlString = buffer.toString("UTF-8");
			XmlMessage message = getXmlMessage(xmlString);
			
	        try (PrintWriter out = new PrintWriter("Receiving.txt")) {
			    out.println(buffer);
			}
	        
	        AudioFile audio = message.operationData.songToAdd;
	        audioManager.addSong(audio);
	        avltree.insert(audio);
	        splaytree.insert(splaykey, audio.album);
	        splaykey ++;
	        //se inserta en el arbol B
	        //se inserta en el arbol Splay
	        
	        System.out.println("Saved song: " + audio.name + audio.author + audio.album + audio.score);
	        	
		} else if (opCode.equals("002")) {
			System.out.println("Sent songs data!");
			
		} else if (opCode.equals("004")) {
			String xmlString = buffer.toString("UTF-8");
			XmlMessage message = getXmlMessage(xmlString);
			
	        try (PrintWriter out = new PrintWriter("Receiving.txt")) {
			    out.println(buffer);
			}
	        
	        AudioFile audio = audioManager.getSong(message.operationData.nameToDel, message.operationData.authorToDel);
	        if (audioManager.deleteSong(audio)) {
	        	System.out.println("Song deleted!");
	        } else {
	        	System.out.println("Unable to delete song :(");
	        }
			
		} else if (opCode.equals("005")) {
			System.out.println("Updated song!");
			
		}else if (opCode.equals("006")) {//add user
			String xmlString = buffer.toString("UTF-8");
			XmlMessage message = getXmlMessage(xmlString);
			
	        try (PrintWriter out = new PrintWriter("Receiving.txt")) {
			    out.println(buffer);
			}
	        
	        //List<User> users = UserManager.users;
	        User user= message.operationData.userToAdd;
	       // System.out.println(users.isEmpty()); Debugging
	        if(userManager.addUser(user)){
	        		System.out.println("Saved user: " +" "+ user.name +" "+ user.lastname +" "+ user.nickname +" "+ user.password +" "+ user.age);
	       // System.out.println(users.isEmpty()); Debugging
	        		userManager.updateUsersFile();
	        }
	        else {
	        	System.out.println("Username Already In use");
	        }
	        
		}else if (opCode.equals("007")) {//add user
			String xmlString = buffer.toString("UTF-8");
			XmlMessage message = getXmlMessage(xmlString);
			
	        try (PrintWriter out = new PrintWriter("Receiving.txt")) {
			    out.println(buffer);
	        }
	        User user= message.operationData.userToLog;
	       // System.out.println(user.nickname); Debugging
	        if(userManager.checkUser(user)) {
	        
	        	System.out.println("logged in as " + user.nickname);
	        }
	        else {
	        	System.out.println("No such combination of user and password");
	        }
		}
		
	}
	
	public XmlMessage getXmlMessage(String xmlString) throws JAXBException {
        JAXBContext jaxbContext = JAXBContext.newInstance(XmlMessage.class);
        Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
        StringReader reader = new StringReader(xmlString);        
        return (XmlMessage) unmarshaller.unmarshal(reader);
	}
	
	public void updateJSON() {
		audioManager.updateSongsFile();
		userManager.updateUsersFile();
	}
	
	
	
	/*
	public String getXmlString(XmlMessage xml) throws JAXBException {
		JAXBContext jaxbContext = JAXBContext.newInstance(XmlMessage.class);
        Marshaller marshaller = jaxbContext.createMarshaller();
        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        StringWriter writer = new StringWriter();
        marshaller.marshal(xml, writer);
        return writer.toString();
	}
	*/
	
	/*
	private String unmarshall(String message) throws JAXBException {
		String cleanXMLString = null;
		Pattern pattern = null;
		Matcher matcher = null;
		pattern = Pattern.compile("[\\000]*");
		matcher = pattern.matcher(message);
		
		if (matcher.find()) {
		   cleanXMLString = matcher.replaceAll("");
		}
		
		JAXBContext jaxbContext = JAXBContext.newInstance(XmlMessage.class);
		Unmarshaller unmarshaller = jaxbContext.createUnmarshaller();
		StringReader reader = new StringReader(cleanXMLString);
		XmlMessage xml = (XmlMessage) unmarshaller.unmarshal(reader);
		return xml.run();
	}
	*/

	/*
	private void createXML(String xmlString) {
		try {

			// Turn xml string into a document
			Document document = DocumentBuilderFactory.newInstance().newDocumentBuilder()
					.parse(new InputSource(new ByteArrayInputStream(xmlString.getBytes("utf-8"))));

			// Remove whitespaces outside tags
			document.normalize();
			XPath xPath = XPathFactory.newInstance().newXPath();
			NodeList nodeList = (NodeList) xPath.evaluate("//text()[normalize-space()='']", document,
					XPathConstants.NODESET);

			for (int i = 0; i < nodeList.getLength(); ++i) {
				Node node = nodeList.item(i);
				node.getParentNode().removeChild(node);
			}

			// Format the xml file
			Transformer transformer = TransformerFactory.newInstance().newTransformer();
			transformer.setOutputProperty(OutputKeys.INDENT, "yes");
			transformer.setOutputProperty("{http://xml.apache.org/xslt}indent-amount", "2");

			// Initialize StreamResult with File object to save to file
			StreamResult result = new StreamResult(new File("Macarena.xml"));
			DOMSource source = new DOMSource(document);
			transformer.transform(source, result);

		} catch (Exception e) {

		}

	}
	*/

}
