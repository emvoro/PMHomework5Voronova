CREATE FUNCTION select_users_notes_count()
RETURNS TABLE(id int, first_name varchar, last_name varchar, notes_count int)
AS $$
    SELECT id, first_name, last_name, COUNT(users.id)
    FROM users
    LEFT JOIN notes
    ON users.id = notes.user_id
    WHERE NOT notes.is_deleted
    GROUP BY users.id, users.first_name, users.last_name
$$ LANGUAGE sql;