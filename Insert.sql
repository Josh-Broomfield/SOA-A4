INSERT INTO Customer VALUES
('Joe', 'Bzolay', '555-555-1212'),
('Nancy', 'Finklbaum', '555-235-4578'),
('Henry', 'Svitzinski', '555-326-8456')

INSERT INTO Product VALUES
('Grapple Grommet', 0.02, 0.005, 1),
('Wandoozals', 2.35, 0.532, 1),
('Kardoofals', 8.75, 5.650, 0)

INSERT INTO [Order] VALUES
(/*1,*/ 1, 'GRAP-09-2011-001', '2011-09-15'),
(/*2,*/ 1, 'GRAP-09-2011-056', '2011-09-30'),
(/*3,*/ 3, NULL, '2011-10-05')

INSERT INTO Cart VALUES
(1, 1, 500),
(1, 2, 1000),
(2, 3, 10),
(3, 1, 75),
(3, 2, 15),
(3, 3, 5)