CREATE FUNCTION select_note(note_id uuid)
RETURNS TABLE(id uuid,
            header varchar,
            body varchar,
            is_deleted bool,
            modified_at timestamptz,
            user_id int,
            first_name varchar,
            last_name varchar)
AS $$
    SELECT
        notes.id, notes.header, notes.body, notes.is_deleted, notes.modified_at,
           notes.user_id, users.first_name, users.last_name
    FROM notes
    LEFT JOIN users
    ON notes.user_id = users.id
    WHERE notes.id = note_id
$$ LANGUAGE sql;