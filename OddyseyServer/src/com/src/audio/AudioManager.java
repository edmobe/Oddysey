package com.src.audio;

import java.io.IOException;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.src.main.MainClass;

public class AudioManager extends MainClass {

	public void addAudio(AudioFile s) throws JsonGenerationException, JsonMappingException, IOException {

		// GUARDA EN EL JSON
		this.getMapper().writerWithDefaultPrettyPrinter().writeValue(this.getAudios(), s);

		// GUARDAR LA CANCION EN LA CARPETA

	}

	public void deleteAudio(AudioFile s) {

	}

	public void synchronizemetadata(AudioFile s) {

	}

	// metodo que agrega los buffers
}
