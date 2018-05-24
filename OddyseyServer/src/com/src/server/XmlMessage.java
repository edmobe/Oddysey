package com.src.server;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name = "XmlMessage")
public class XmlMessage {
	
	@XmlElement(name = "OpCode")
	public String opCode;
	@XmlElement(name = "OpData")
	public OperationData opData;
	
	public String run() {
		
		if (opCode.equals("001")) {
			return "Agregada";
		}
		else if (opCode.equals("002")) {
			return "Borrada";
		} else {
			return "Error";
		}
	}
}
