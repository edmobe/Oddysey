package com.src.server;

import java.io.File;
import java.io.StringWriter;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.JAXB;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

@XmlRootElement(name = "XmlMessage")
public class XmlMessage {
	
	@XmlElement(name = "OperationData")
	public OperationData operationData;
	
	public XmlMessage() {
		operationData = new OperationData();
	}
	
	public String getXmlString() {
		try {
			JAXBContext jaxbContext = JAXBContext.newInstance(XmlMessage.class);
	        Marshaller marshaller = jaxbContext.createMarshaller();
	        marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
	        StringWriter writer = new StringWriter();
	        marshaller.marshal(this, writer);
	        return writer.toString();
		} catch (JAXBException e) {
			e.printStackTrace();
		}
		return null;
	}
	
}


