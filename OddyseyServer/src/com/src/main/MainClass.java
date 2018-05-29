package com.src.main;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.src.audio.AudioManager;
import com.src.login.LogInManager;
import com.src.server.Server;

public class MainClass {

	public static void main(String[] args) { // pruebas
		
		Server s1 = new Server();

		JFrame frame = new JFrame("Oddysey Server");
		frame.setSize(400, 400);
		
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLocationRelativeTo(null);

		Icon closeImage = new ImageIcon("stop.png");
		JButton close = new JButton(closeImage);
		
		close.addActionListener(new ActionListener() {
		    public void actionPerformed(ActionEvent e)
		    {
		    	s1.updateJSON();
		    	System.exit(1);
		    }
		});
		
		frame.add(close, BorderLayout.CENTER);
		
		frame.setVisible(true);
		
		s1.run();
	}

}
