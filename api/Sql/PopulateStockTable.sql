USE Finshark;

INSERT INTO Stocks (Symbol, CompanyName, Purchase, LastDiv, Industry, MarketCap) VALUES
('TSLA', 'Tesla', 100, 2.00, 'Automotive', 23456789),
('MSFT', 'Microsoft', 100, 1.20, 'Technology', 23456789),
('VTI', 'Vanguard Total Index', 200, 2.10, 'Index Fund', 23456789),
('PLTR', 'Plantir', 23, 0, 'Technology', 45645456);

INSERT INTO Comments (Title, Content, CreatedOn, StockId) VALUES
('Test comment', 'Test content', convert(datetime,'25-12-98 10:34:09 PM', 5), 4);