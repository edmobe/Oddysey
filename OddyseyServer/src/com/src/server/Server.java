package com.src.server;


import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.StringReader;
import java.io.UnsupportedEncodingException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.transform.Transformer;
import javax.xml.transform.stream.StreamResult;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;


/**
 * Apps server
 * 
 * @author edmobe
 *
 */
public class Server extends Thread{
	
	private static String opCode;
	private static String opCodeMessage;
	
	/**
	 * Runs the Socket loop.
	 */
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
		        String[] firstMessage = buffer.toString("UTF-8").split("/");
		        opCode = firstMessage[0];
		        opCodeMessage = firstMessage[1]; // Message attached to the OPCode (needs reply)
		        
		        System.out.println("OPCode: " + opCode + ". First message: " + opCodeMessage);
		        
		        
		        // Re-open (literally the one and only way I found to make this work)
		        socket = serverSocket.accept();
		        is = socket.getInputStream();
		        os = socket.getOutputStream();
		        
		        // Sending message based on OPCode
		        reply(os, opCode);		        
		        
		        // Getting message
		        buffer = new ByteArrayOutputStream();
		        data = new byte[16384];
		        while ((nRead = is.read(data, 0, data.length)) != -1) {
		          buffer.write(data, 0, nRead);
		        }

		        String received = buffer.toString("UTF-8"); // Message for server usage (does not need reply)
		        
		        receive(received, opCode);		        
		        
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
	private void reply(OutputStream os, String opCode) throws UnsupportedEncodingException, IOException {
		String toSend = "OPCode not defined";
		if (opCode.equals("001")) { // Add song
			toSend = "Got the OPCode " + opCode + " (add song).";			
		} else if(opCode.equals("002")) { // Send list of songs
			String test1 = "Macarena\\Los del Rio\\110\\5\\One\\Metallica\\550\\5";
			String test2 = "Macarena\\Los del Rio\\110\\5\\One\\Metallica\\550\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5\\RandomTitle\\RandomArtist\\RandomAlbum\\5";
			toSend = test2; // Aquí debería convertir la lista (o el árbol o lo que sea) de canciones a un String en formato Xml.
		}
		os.write(toSend.getBytes("UTF-8"));
	}
	
	/**
	 * Decides which operation to with the received input based on the operation code.
	 * @param received input {@code String}
	 * @param opCode operation code
	 * @throws JAXBException
	 * @throws FileNotFoundException
	 */
	private void receive(String received, String opCode) throws JAXBException, FileNotFoundException {
		if (opCode.equals("001")) { // Add song
			// For testing
	        try (PrintWriter out = new PrintWriter("Receiving.txt")) {
			    out.println(received);
			}
	        System.out.println("Saved song!");
			// Aquí va el algoritmo para agregar received al JSON de canciones
		} 
	}
	
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
