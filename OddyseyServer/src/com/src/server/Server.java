package com.src.server;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
//import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
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
	
	public void run() {
		
		try {
			@SuppressWarnings("resource")
			ServerSocket serverSocket = new ServerSocket(5000, 10); // INVESTIGAR SIGNIFICADO DE BACKLOG
			
			while (true) {
				
				Socket socket = serverSocket.accept();
				InputStream is = socket.getInputStream();
				//OutputStream os = socket.getOutputStream();
				
				// Receiving
				byte[] lenBytes = new byte[4]; // yo creo que son los chunks
				is.read(lenBytes, 0, 4);
				int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) | ((lenBytes[1] & 0xff) << 8)
						| (lenBytes[0] & 0xff)); // no s[e qu[e es esto :(
				byte[] receivedBytes = new byte[len];
				is.read(receivedBytes, 0, len);
				String received = new String(receivedBytes, 0, len);
				System.out.println(received);
				
				// Sending
//				String toSend = "Echo: " + received;
//				byte[] toSendBytes = toSend.getBytes();
//				int toSendLen = toSendBytes.length;
//				byte[] toSendLenBytes = new byte[4];
//				toSendLenBytes[0] = (byte) (toSendLen & 0xff);
//				toSendLenBytes[1] = (byte) ((toSendLen >> 8) & 0xff);
//				toSendLenBytes[2] = (byte) ((toSendLen >> 16) & 0xff);
//				toSendLenBytes[3] = (byte) ((toSendLen >> 24) & 0xff);
//				os.write(toSendLenBytes);
//				os.write(toSendBytes);

				createXML(received);
				
				socket.close();
				
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

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
			StreamResult result = new StreamResult(new File("Test.xml"));
			DOMSource source = new DOMSource(document);
			transformer.transform(source, result);

		} catch (Exception e) {

		}

	}

}
