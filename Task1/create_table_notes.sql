CREATE TABLE IF NOT EXISTS notes (
     id uuid PRIMARY KEY,
     header varchar NOT NULL,
     body varchar NOT NULL,
     is_deleted  bool NOT NULL,
     modified_at timestamptz default current_timestamp,
     user_id int NOT NULL,
     FOREIGN KEY (user_id) REFERENCES users(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE INDEX ON notes(modified_at);