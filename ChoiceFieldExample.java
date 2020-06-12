package com.itext.choicefieldbug;

import com.itextpdf.forms.PdfAcroForm;
import com.itextpdf.kernel.pdf.PdfDocument;
import com.itextpdf.kernel.pdf.PdfReader;
import com.itextpdf.kernel.pdf.PdfWriter;

public class ChoiceFieldExample {

	private static final String SRC = "src/main/resources/choicefieldbug/";
	private static String srcPdf = SRC + "choiceFieldsWithUnnecessaryIEntries.pdf";
	private static String outPdf = SRC + "choiceFieldsSetValueTest.pdf";

	public static void main(String[] args) throws Exception {
		// TODO Auto-generated method stub
		generatePDF();

	}

	public static void generatePDF() throws Exception {

		PdfDocument pdfDocument = new PdfDocument(new PdfReader(srcPdf), new PdfWriter(outPdf));
		PdfAcroForm form = PdfAcroForm.getAcroForm(pdfDocument, false);
		form.getField("First").setValue("First");
		form.getField("Second").setValue("Second");
		pdfDocument.close();

	}

}
