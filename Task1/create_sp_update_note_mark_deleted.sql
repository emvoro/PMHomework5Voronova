CREATE FUNCTION update_note_mark_deleted(note_id uuid)
AS $$
    UPDATE notes set is_deleted = true WHERE id = note_id
$$
LANGUAGE sql;