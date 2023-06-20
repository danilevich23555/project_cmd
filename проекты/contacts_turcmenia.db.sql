BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "contacts" (
	"abonent_number"	text NOT NULL,
	"contact_number"	text NOT NULL,
	"name_contact"	text NOT NULL
);
CREATE TABLE IF NOT EXISTS "reg_data" (
	"number"	TEXT,
	"fio"	text,
	"address"	text,
	"passport"	text,
	"date_place"	text,
	"cod006"	text
);
CREATE INDEX IF NOT EXISTS "ix_contacts" ON "contacts" (
	"abonent_number",
	"contact_number",
	"name_contact"
);
CREATE INDEX IF NOT EXISTS "ix_reg_data" ON "reg_data" (
	"number"
);
CREATE INDEX IF NOT EXISTS "fio_reg_data" ON "reg_data" (
	"fio"
);
COMMIT;
