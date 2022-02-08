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

		//FlushAll(dbcon);

		// Create table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS basic_cards (id INTEGER PRIMARY KEY, name TEXT, rarity INTEGER, isActive INTEGER)";
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		//dbcmd = dbcon.CreateCommand();
		//q_createTable = "CREATE TABLE IF NOT EXISTS version_info (id INTEGER PRIMARY KEY, description TEXT)";
		//dbcmd.CommandText = q_createTable;
		//dbcmd.ExecuteReader();

		bool populated = CheckIfPopulated(dbcon);
		//bool populated = false;
		if (!populated)
        {
			// Insert values in table
			IDbCommand cmnd = dbcon.CreateCommand();
			cmnd.CommandText = @"
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (0, 0, 1, 'Aari McDonald');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (1, 0, 1, 'Chennedy Carter');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (2, 0, 1, 'Odyssey Sims');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (3, 0, 1, 'Tiffany Hayes');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (4, 0, 1, 'Courtney Williams');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (5, 0, 1, 'Elizabeth Williams');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (6, 0, 1, 'Monique Billings');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (7, 0, 1, 'Shekinna Stricklen');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (8, 0, 1, 'Tianna Hawkins');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (9, 0, 1, 'Allie Quigley');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (10, 0, 1, 'Candace Parker');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (11, 0, 1, 'Diamond DeShields');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (12, 0, 1, 'Courtney Vandersloot');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (13, 0, 1, 'Kahleah Copper');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (14, 0, 1, 'Ruthy Hebard');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (15, 0, 1, 'Shyla Heal');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (16, 0, 1, 'Stefanie Dolson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (17, 0, 1, 'Alyssa Thomas');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (18, 0, 1, 'Briann January');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (19, 0, 1, 'Brionna Jones');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (20, 0, 1, 'DeWanna Bonner');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (21, 0, 1, 'Jasmine Thomas');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (22, 0, 1, 'Jonquel Jones');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (23, 0, 1, 'Arike Ogunbowale');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (24, 0, 1, 'Awak Kuier');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (25, 0, 1, 'Charli Collier');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (26, 0, 0, 'Cheryl Ford');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (27, 0, 1, 'Allisha Gray');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (28, 0, 1, 'Chelsea Dungee');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (29, 0, 1, 'Isabelle Harrison');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (30, 0, 1, 'Kayla Thornton');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (31, 0, 1, 'Marina Mabrey');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (32, 0, 1, 'Moriah Jefferson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (33, 0, 1, 'Satou Sabally');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (34, 0, 1, 'Kelsey Mitchell');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (35, 0, 1, 'Aaliyah Wilson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (36, 0, 1, 'Danielle Robinson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (37, 0, 1, 'Jantel Lavender');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (38, 0, 1, 'Kysre Gondrezick');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (39, 0, 1, 'Lauren Cox');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (40, 0, 1, 'Teaira McCowan');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (41, 0, 1, 'Tiffany Mitchell');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (42, 0, 1, 'Victoria Vivians');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (43, 0, 1, 'A''ja Wilson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (44, 0, 1, 'Angel McCoughtry');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (45, 0, 0, 'Becky Hammon');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (46, 0, 1, 'Dearica Hamby');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (47, 0, 1, 'Jackie Young');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (48, 0, 1, 'Liz Cambage');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (49, 0, 1, 'Chelsea Gray');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (50, 0, 1, 'Iliana Rupert');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (51, 0, 1, 'Kelsey Plum');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (52, 0, 1, 'Riquna Williams');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (53, 0, 1, 'Chiney Ogwumike');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (54, 0, 1, 'Erica Wheeler');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (55, 0, 0, 'Lisa Leslie');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (56, 0, 1, 'Nneka Ogwumike');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (57, 0, 1, 'Amanda Zahui B.');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (58, 0, 1, 'Bria Holmes');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (59, 0, 1, 'Brittney Sykes');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (60, 0, 1, 'Jasmine Walker');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (61, 0, 1, 'Kristi Toliver');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (62, 0, 1, 'Nia Coffey');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (63, 0, 1, 'Stephanie Watts');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (64, 0, 1, 'Crystal Dangerfield');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (65, 0, 1, 'Kayla McBride');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (66, 0, 1, 'Napheesa Collier');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (67, 0, 1, 'Aerial Powers');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (68, 0, 1, 'Bridget Carleton');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (69, 0, 1, 'Damiris Dantas');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (70, 0, 1, 'Rennia Davis');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (71, 0, 1, 'Sylvia Fowles');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (72, 0, 1, 'Betnijah Laney');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (73, 0, 1, 'Sabrina Ionescu');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (74, 0, 1, 'Jocelyn Willoughby');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (75, 0, 1, 'Kylee Shook');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (76, 0, 1, 'Layshia Clarendon');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (77, 0, 1, 'Michaela Onyenwere');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (78, 0, 1, 'Natasha Howard');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (79, 0, 1, 'Sami Whitcomb');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (80, 0, 0, 'Cynthia Cooper-Dyke');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (81, 0, 0, 'Sheryl Swoopes');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (82, 0, 1, 'Brittney Griner');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (83, 0, 1, 'Diana Taurasi');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (84, 0, 1, 'Kia Nurse');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (85, 0, 1, 'Skylar Diggins-Smith');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (86, 0, 1, 'Alanna Smith');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (87, 0, 1, 'Brianna Turner');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (88, 0, 1, 'Kia Vaughn');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (89, 0, 1, 'Sophie Cunningham');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (90, 0, 1, 'Breanna Stewart');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (91, 0, 0, 'Lauren Jackson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (92, 0, 1, 'Sue Bird');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (93, 0, 1, 'Candice Dupree');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (94, 0, 1, 'Epiphanny Prince');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (95, 0, 1, 'Ezi Magbegor');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (96, 0, 1, 'Jewell Loyd');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (97, 0, 1, 'Jordin Canada');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (98, 0, 1, 'Katie Lou Samuelson');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (99, 0, 1, 'Elena Delle Donne');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (100, 0, 1, 'Myisha Hines-Allen');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (101, 0, 1, 'Tina Charles');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (102, 0, 1, 'Ariel Atkins');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (103, 0, 1, 'Emma Meesseman');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (104, 0, 1, 'Leilani Mitchell');
								INSERT OR IGNORE INTO basic_cards (id, rarity, isActive, name) VALUES (105, 0, 1, 'Natasha Cloud');";
			cmnd.ExecuteNonQuery();
		}

		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query = "SELECT id FROM basic_cards WHERE isActive == 1 ORDER BY RANDOM() LIMIT 5;";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		int counter = 0;
		while (reader.Read())
		{
			pulls.Add(reader[0].ToString());
			//Debug.Log("Id: " + pulls[counter].ToString());
			cards[counter].GetComponent<Image>().sprite = images[Int32.Parse(pulls[counter].ToString())];
			counter++;
		}

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
