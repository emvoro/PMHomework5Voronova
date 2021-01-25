CREATE FUNCTION insert_note(note_id uuid, header varchar, body varchar, user_id int)
RETURNS void AS $$
    INSERT INTO notes
    VALUES (note_id, header, body, false, user_id)
    $$
LANGUAGE sql;
