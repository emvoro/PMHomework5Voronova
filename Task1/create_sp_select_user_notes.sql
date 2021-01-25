CREATE FUNCTION select_user_notes(id_user int)
RETURNS TABLE(id uuid, header varchar, body varchar, is_deleted bool, modified_at timestamptz, user_id int)
AS $$
    SELECT * FROM notes WHERE notes.user_id = id_user AND NOT notes.is_deleted
$$
LANGUAGE sql;