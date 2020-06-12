package com.itext.ImageIssue;

import java.io.IOException;

import org.apache.commons.codec.binary.Base64;

import com.itextpdf.io.image.ImageDataFactory;
import com.itextpdf.kernel.pdf.PdfDocument;
import com.itextpdf.kernel.pdf.PdfWriter;
import com.itextpdf.layout.Document;
import com.itextpdf.layout.element.Image;

public class FixPNGIssue {

	public static final String DEST = "src/main/resources/imageissue/output.pdf";

	public static void main(String[] args) throws Exception {
		// TODO Auto-generated method stub
		new FixPNGIssue().generatePDF(DEST);

	}

	public void generatePDF(String dest) throws IOException {
		PdfDocument pdf = new PdfDocument(new PdfWriter("Destination PDF path"));
		Document document = new Document(pdf);

		// Set the problematic base64 encoded image
		String dataSrc = "encoded png image string";
		byte[] data = Base64.decodeBase64(dataSrc);
		Image image = new Image(ImageDataFactory.create(data));
		document.add(image);
		document.close();
	}

}
