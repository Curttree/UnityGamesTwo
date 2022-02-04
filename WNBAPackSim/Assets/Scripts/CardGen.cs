using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CardGen : MonoBehaviour
{
	public GameObject[] cards;
	public Sprite[] images = new Sprite[106];
	private List<string> pulls = new List<string>();
    // Start is called before the first frame update
    void Start()
	{
		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "WNBA2021_v1";

		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();

		FlushAll(dbcon);

		// Create table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS basic_cards (id INTEGER PRIMARY KEY, name TEXT, rarity INTEGER, image TEXT)";
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		//dbcmd = dbcon.CreateCommand();
		//q_createTable = "CREATE TABLE IF NOT EXISTS version_info (id INTEGER PRIMARY KEY, description TEXT)";
		//dbcmd.CommandText = q_createTable;
		//dbcmd.ExecuteReader();

		//bool populated = CheckIfPopulated(dbcon);
		bool populated = false;
		if (!populated)
        {
			// Insert values in table
			IDbCommand cmnd = dbcon.CreateCommand();
			cmnd.CommandText = @"INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (0, 'Aari McDonald', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (1, 'Chennedy Carter', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (2, 'Odyssey Sims', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (3, 'Tiffany Hayes', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (4, 'Courtney Williams', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (5, 'Elizabeth Williams', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (6, 'Monique Billings', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (7, 'Shekinna Stricklen', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (8, 'Tianna Hawkins', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (9, 'Allie Quigley', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (10, 'Candace Parker', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (11, 'Diamond DeShields', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (12, 'Courtney Vandersloot', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (13, 'Kahleah Copper', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (14, 'Ruthy Hebard', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (15, 'Shyla Heal', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (16, 'Stefanie Dolson', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (17, 'Alyssa Thomas', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (18, 'Briann January', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (19, 'Brionna Jones', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (20, 'DeWanna Bonner', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (21, 'Jasmine Thomas', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (22, 'Jonquel Jones', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (23, 'Arike Ogunbowale', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (24, 'Awak Kuier', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (25, 'Charli Collier', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (26, 'Cheryl Ford', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (27, 'Allisha Gray', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (28, 'Chelsea Dungee', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (29, 'Isabelle Harrison', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (30, 'Kayla Thornton', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (31, 'Marina Mabrey', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (32, 'Moriah Jefferson', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (33, 'Satou Sabally', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (34, 'Kelsey Mitchell', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (35, 'Aaliyah Wilson', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (36, 'Danielle Robinson', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (37, 'Jantel Lavender', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (38, 'Kysre Gondrezick', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (39, 'Lauren Cox', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (40, 'Teaira McCowan', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (41, 'Tiffany Mitchell', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (42, 'Victoria Vivians', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (43, 'A''ja Wilson', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (44, 'Angel McCoughtry', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (45, 'Becky Hammon', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (46, 'Dearica Hamby', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (47, 'Jackie Young', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (48, 'Liz Cambage', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (49, 'Chelsea Gray', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (50, 'Iliana Rupert', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (51, 'Kelsey Plum', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (52, 'Riquna Williams', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (53, 'Chiney Ogwumike', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (54, 'Erica Wheeler', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (55, 'Lisa Leslie', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (56, 'Nneka Ogwumike', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (57, 'Amanda Zahui B.', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (58, 'Bria Holmes', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (59, 'Brittney Sykes', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (60, 'Jasmine Walker', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (61, 'Kristi Toliver', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (62, 'Nia Coffey', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (63, 'Stephanie Watts', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (64, 'Crystal Dangerfield', 1,'crystal.jpg');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (65, 'Kayla McBride', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (66, 'Napheesa Collier', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (67, 'Aerial Powers', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (68, 'Bridget Carleton', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (69, 'Damiris Dantas', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (70, 'Rennia Davis', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (71, 'Sylvia Fowles', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (72, 'Betnijah Laney', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (73, 'Sabrina Ionescu', 1,'sabrina.jpg');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (74, 'Jocelyn Willoughby', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (75, 'Kylee Shook', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (76, 'Layshia Clarendon', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (77, 'Michaela Onyenwere', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (78, 'Natasha Howard', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (79, 'Sami Whitcomb', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (80, 'Cynthia Cooper-Dyke', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (81, 'Sheryl Swoopes', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (82, 'Brittney Griner', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (83, 'Diana Taurasi', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (84, 'Kia Nurse', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (85, 'Skylar Diggins-Smith', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (86, 'Alanna Smith', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (87, 'Brianna Turner', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (88, 'Kia Vaughn', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (89, 'Sophie Cunningham', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (90, 'Breanna Stewart', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (91, 'Lauren Jackson', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (92, 'Sue Bird', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (93, 'Candice Dupree', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (94, 'Epiphanny Prince', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (95, 'Ezi Magbegor', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (96, 'Jewell Loyd', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (97, 'Jordin Canada', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (98, 'Katie Lou Samuelson', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (99, 'Elena Delle Donne', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (100, 'Myisha Hines-Allen', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (101, 'Tina Charles', 1,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (102, 'Ariel Atkins', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (103, 'Emma Meesseman', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (104, 'Leilani Mitchell', 0,'');
								INSERT OR IGNORE INTO basic_cards (id, name, rarity, image) VALUES (105, 'Natasha Cloud', 0,'');";
			cmnd.ExecuteNonQuery();
		}

		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT id FROM basic_cards WHERE image <> '' ORDER BY RANDOM() LIMIT 5;";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		int counter = 0;
		while (reader.Read())
		{
			pulls.Add(reader[0].ToString());
			Debug.Log("Id: " + pulls[counter].ToString());
			counter++;
		}

		cards[0].GetComponent<Image>().sprite = images[Int32.Parse(pulls[0].ToString())];

		// Close connection
		dbcon.Close();

	}

	// Update is called once per frame
	void Update()
    {
        
    }

	bool CheckIfPopulated(IDbConnection dbcon)
    {
		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT COUNT(id) FROM basic_cards";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();
		if (reader[0].ToString() == "0")
        {
			return false;
        }
		return true;
	}

	void FlushAll(IDbConnection dbcon)
    {

		// FLUSH table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "DROP TABLE basic_cards";
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();
	}
}
