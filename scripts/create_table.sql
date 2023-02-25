CREATE TABLE IF NOT EXISTS Simian (
    id SERIAL PRIMARY KEY,
    dna VARCHAR (250) NOT NULL UNIQUE,
    is_simian BOOLEAN NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);


CREATE TABLE IF NOT EXISTS SimianCalc (
    id Date NOT NULL PRIMARY KEY,
    total numeric NOT NULL,
    count_is_simian numeric NOT NULL,
    count_is_not_simian numeric NOT NULL,
    is_simian_percent numeric GENERATED ALWAYS AS (count_is_simian / total) STORED,
    is_not_simian_percent numeric GENERATED ALWAYS AS (count_is_not_simian / total) STORED,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);
