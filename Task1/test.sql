SELECT insert_user('Emilia', 'Voronova');
SELECT insert_user('Valeria', 'Radchenko');

SELECT insert_note('f9168c5e-ceb2-4faa-b6bf-329bf39fa1e4', 'first', 'my first note ever', 1);
SELECT insert_note('0f8fad5b-d9cb-469f-a165-70867728950e', 'second', 'second note haha', 1);

SELECT select_users_notes_count();

SELECT insert_note('7c9e6679-7425-40de-944b-e07fc1f90ae7', 'food', 'i want to eat taco so bad', 2);

SELECT select_users_notes_count();

SELECT select_user_notes(1);
SELECT select_user_notes(2);

SELECT select_note('f9168c5e-ceb2-4faa-b6bf-329bf39fa1e4');
SELECT select_note('7c9e6679-7425-40de-944b-e07fc1f90ae7');

SELECT update_note_mark_deleted('0f8fad5b-d9cb-469f-a165-70867728950e');

SELECT select_user_notes(1);

SELECT update_note_mark_deleted('7c9e6679-7425-40de-944b-e07fc1f90ae7');

SELECT select_users_notes_count();

