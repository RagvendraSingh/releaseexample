public void testCoreEvent() {
    // Use com.itextpdf.kernel.counter.IEventCounterFactory implementation.
    // SimpleEventCounterFactory is the most basic one, simply yielding an instance which is passed to the constructor.
    IEventCounterFactory counterFactory = new SimpleEventCounterFactory(new CustomEventCounter());
    EventCounterHandler.getInstance().register(counterFactory);
    LicenseKey.loadLicenseFile(license);
    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new ByteArrayOutputStream()));
    pdfDocument.addNewPage();
    pdfDocument.close();

    EventCounterHandler.getInstance().unregister(counterFactory);
}

class CustomEventCounter extends EventCounter {

    @Override
    protected void onEvent(IEvent event, IMetaInfo metaInfo) {
        // This implementation is not thread safe!
        System.out.println("Process event: " + event.getEventType());
    }
}