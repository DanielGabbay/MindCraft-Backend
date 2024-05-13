To AI: 
אפיון:
שם האפליקציה: NoteAI (זמני ככל הנראה)

נתונים:
* הקלטת קול -> טקסט
* מידע טקסטואלי שהמשתמש מזין / מייבא ממקור חיצוני / שירות חיצוני (לדוגמה פלט שיחת וואטסאפ או תכתובות מייל)
* תמונות / סריקות

תוצרים אפשריים: (לדוגמה המשתמש יכול לבחור מספר רשומות ממה שהוגדר בנתונים למעלה ולבחור תוצר רצוי)
* בניית רשימת משימות
* ייצוא סיכום
* הצעות והמלצות למשתמש
* בניית קונטקסים גנריים על סמך הנתונים של המשתמש והלמידה

טכנולוגיות מבוססות AI
---
Generate me controllers for the entities in the notes app.
Note.cs:
- Post - Create a new note
- Get - Get all notes
- Get - Get a note by id
- Put - Update a note
- Delete - Delete a note
- Get - Get all notes by user id
- Get - Get all notes by tag id

File.cs:
- Post - Upload a file
- Get - Get all files uploaded by user id
- Get - Get a file by id
- Delete - Delete a file

FileAttachment.cs:
- Post - Attach a file to a note
- Get - Get all attachments by note id
- Delete - Delete an attachment by id
- Get - Get all attachments by user id

Tag.cs:
- POST - Create a tag (UserTag) for the user (User) or group (Group)
- GET - Get all tags for the user or group
- PUT - Update a tag for the user or group (only creator can update)
- DELETE - Delete a tag for the user or group (only creator can delete)

User.cs:
- POST - Create a user (User)
- GET - Get all users
- GET - Get a user by id
- PUT - Update a user
- DELETE - Delete a user
- GET - Get all users by group id

// Controllers creation sh script
// touch NoteController.cs FileController.cs FileAttachmentController.cs TagController.cs UserController.cs GroupController.cs


//FileRepository, FileAttachmentRepository, TagRepository, and UserRepository
touch FileRepository.cs FileAttachmentRepository.cs TagRepository.cs UserRepository.cs GroupRepository.cs
touch IFIleRepository.cs IFileAttachmentRepository.cs ITagRepository.cs IUserRepository.cs IGroupRepository.cs