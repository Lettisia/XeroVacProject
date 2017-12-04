

-- Table: location

DROP TABLE IF EXISTS location CASCADE;

CREATE TABLE location
(
    id integer NOT NULL,
    name character varying(100),
    e integer,
    w integer,
    n integer,
    s integer,
    description character varying(250),
    verbosedescription varchar(10000),
	isstart boolean NOT NULL DEFAULT false,
	PRIMARY KEY (id),
	FOREIGN KEY (e) REFERENCES location (id) ,
	FOREIGN KEY (w) REFERENCES location (id) ,
	FOREIGN KEY (s) REFERENCES location (id) ,
	FOREIGN KEY (n) REFERENCES location (id) 
);

ALTER TABLE location
    OWNER to "Tombstone";





	
-- Table: player

DROP TABLE IF EXISTS player CASCADE;

CREATE TABLE player
(
    id integer NOT NULL,
    playername character varying(100),
	PRIMARY KEY (id)
);

ALTER TABLE player
    OWNER to "Tombstone";
	
	
	
	


-- Table: character

DROP TABLE IF EXISTS character CASCADE;

CREATE TABLE character
(
    id integer NOT NULL,
    charactername character varying(100),
    characterdescription character varying(250),
    locationid integer,
    PRIMARY KEY (id),
    FOREIGN KEY (locationid) REFERENCES location (id) 
);

ALTER TABLE character
    OWNER to "Tombstone";


	
	
	
	
	
	
-- Table: item

DROP TABLE IF EXISTS item CASCADE;

CREATE TABLE item
(
    id integer NOT NULL,
    name character varying(100),
    description character varying(250),
    locationid integer,
    isvisible bool,
    PRIMARY KEY (id),
    FOREIGN KEY (locationid) REFERENCES location (id)
);

ALTER TABLE item
    OWNER to "Tombstone";

	

	
	
	
-- Table: inventory

-- DROP TABLE IF EXISTS inventory CASCADE;

-- CREATE TABLE inventory
-- (
--     id integer NOT NULL,
--     playerid integer,
--     PRIMARY KEY (id),
--     FOREIGN KEY (playerid) REFERENCES player (id) 
-- );
 
-- ALTER TABLE inventory
--     OWNER to "Tombstone";


	

	
	
	
-- Table: commands

DROP TABLE IF EXISTS command CASCADE;

CREATE TABLE command
(
    name character varying(20) NOT NULL,
    description character varying(250),
    PRIMARY KEY (name)
);

ALTER TABLE command
    OWNER to "Tombstone";