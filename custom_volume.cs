        public void testCoreEvent()
        {
            // Use com.itextpdf.kernel.counter.IEventCounterFactory implementation.
            // SimpleEventCounterFactory is the most basic one, simply yielding an instance which is passed to the constructor.
            IEventCounterFactory counterFactory = new SimpleEventCounterFactory(new CustomEventCounter());
            EventCounterHandler.GetInstance().Register(counterFactory);
            LicenseKey.LoadLicenseFile("license path");
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new iText.IO.Source.ByteArrayOutputStream()));
            pdfDocument.AddNewPage();
            pdfDocument.Close();

            EventCounterHandler.GetInstance().Unregister(counterFactory);
        }

        class CustomEventCounter : EventCounter
        {
            protected override void OnEvent(IEvent @event, IMetaInfo metaInfo)
            {
                Console.WriteLine("Process Event: ");
            }
        }