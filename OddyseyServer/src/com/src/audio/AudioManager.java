package com.src.audio;

import java.io.ByteArrayOutputStream;
import java.io.FileWriter;
import java.io.IOException;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.src.main.MainClass;

import org.json.JSONException;
import org.json.JSONObject;
import org.json.XML;

public class AudioManager extends MainClass {

	private FileWriter fl;

	public void addAudio(String b) throws JsonGenerationException, JsonMappingException, IOException {

		
	
		try {
			JSONObject xml = XML.toJSONObject(b);
			String xmlData = xml.toString(4);
			fl = new FileWriter(this.getAudios(), true);
			fl.write(xmlData);
			
		}catch(JSONException je) {
            System.out.println(je.toString());
        }
		
		
		
		/*// GUARDA EN EL JSON
		this.getMapper().
		writerWithDefaultPrettyPrinter().
		writeValue(this.getAudios(), b);

		// GUARDAR LA CANCION EN LA CARPETA
*/
	}

	public void deleteAudio(AudioFile s) {

	}

	public void synchronizemetadata(AudioFile s) {

	}

	// metodo que agrega los buffers
}
