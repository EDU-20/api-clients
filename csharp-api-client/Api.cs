using System;
using System.Net;
using System.IO;
using System.Text;

using System.Collections.Generic;
using System.Collections.Specialized;

namespace csharpapiclient
{
	public class Api
	{
		private string host, api_key;

		public Api (string host, string api_key)
		{
			this.host = host;
			this.api_key = api_key;
		}

		public int GetVersion(){
			Dictionary<string, object> results = Execute("get_version") as Dictionary<string, object>;
			return Convert.ToInt32(EnsureValueFromDictionary(results, "version"));
		}

		public bool IsAuthenticated(string userid, string password) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("userid", userid);
			queryParams.Add("password", password);
			Dictionary<string, object> results = Execute("is_authenticated", queryParams) as Dictionary<string, object>;
			return (bool)EnsureValueFromDictionary (results, "authenticated");
		}

		public Dictionary<string, object> GetMyAccount() {
			return (Dictionary<string, object>) Execute("get_my_account");
		}

		public List<object> GetAllUsers(int page) {
			NameValueCollection queryParams = new NameValueCollection();
		        queryParams.Add("page", page.ToString());
			return (List<object>) Execute("get_all_users", queryParams);
		}

		public List<object> GetUsersWithIds(int[] user_ids){
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter("user_ids[]", user_ids));
			return (List<object>)Execute("get_users_with_ids", queryParams);
		}

		public List<object> GetUsersThatMatch(Dictionary<string, object> queryParamsDict, int page){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
	    		queryParams.Add ("page", page.ToString());
			return (List<object>) Execute("get_users_that_match", queryParams);
		}

		public Dictionary<string, object> AddUser(Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			return (Dictionary<string, object>) Execute("add_user", queryParams);
		}

        public Dictionary<string, object> UpdateUser(Dictionary<string, object> queryParamsDict)
        {
            NameValueCollection queryParams = new NameValueCollection();
            foreach (var queryParam in queryParamsDict)
            {
                queryParams.Add(queryParam.Key, queryParam.Value.ToString());
            }
            return (Dictionary<string, object>)Execute("update_user", queryParams);
        }

        public int ArchiveStudents(int[] student_ids) {
			NameValueCollection queryParams = ToArrayParameter("user_ids[]", student_ids);
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("archive_students", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "archived"));
		}

		public int ReactivateStudents(int[] student_ids) {
			NameValueCollection queryParams = ToArrayParameter ("user_ids[]", student_ids);
			Dictionary<string, object> response = (Dictionary<string, object>)Execute("reactivate_students", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response,"reactivated"));
		}

	// classes

		public List<object> GetAllClasses(int page) {
      			NameValueCollection queryParams = new NameValueCollection();
		  	queryParams.Add("page", page.ToString());			
			return (List<object>) Execute("get_all_classes", queryParams);
		}

		public List<object> GetArchivedClasses(int page) {
	   		NameValueCollection queryParams = new NameValueCollection();
	    		queryParams.Add("archived", "true");
		  	queryParams.Add("page", page.ToString());
	    		return (List<object>) Execute("get_all_classes", queryParams);
	  	}

	  	public List<object> GetClassesWithIDs(int[] class_ids) {
			NameValueCollection queryParams = ToArrayParameter ("class_ids[]", class_ids);
	    		return (List<object>) Execute("get_classes_with_ids", queryParams);
	  	}

	  	public List<object> GetClassesThatMatch(Dictionary<string, object> queryParamsDict, int page){
		  	NameValueCollection queryParams = new NameValueCollection();
		  	foreach (var queryParam in queryParamsDict) {
			    queryParams.Add(queryParam.Key, queryParam.Value.ToString());
	    		}
		  	queryParams.Add("page", page.ToString());
     			return (List<object>) Execute("get_classes_that_match", queryParams);
    		}
    
	  	public List<object> GetClassesForOrganization(int organization_id, int page) {
	    		NameValueCollection queryParams = new NameValueCollection();
		 	queryParams.Add("organization_id", organization_id.ToString());
		  	queryParams.Add("page", page.ToString());
	    		return (List<object>) Execute("get_classes_for_organization", queryParams);
	  	}

	// add class

		public Dictionary<string, object> AddClass(Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection ();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			return (Dictionary<string, object>) Execute("add_class", queryParams);
		}

		public Dictionary<string, object> AddClassFromTemplate(int class_template_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("class_template_id", class_template_id.ToString());
			return (Dictionary<string, object>) Execute("add_class_from_template", queryParams);
		}

		public Dictionary<string, object> AddChildClass(int parent_class_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("parent_class_id", parent_class_id.ToString());
			return (Dictionary<string, object>) Execute("add_child_class", queryParams);
		}

		public Dictionary<string, object> EditClass(int class_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("class_id", class_id.ToString());
			return (Dictionary<string, object>) Execute("edit_class", queryParams);
		}

		public int ArchiveClasses(int[] class_ids) {
		  	NameValueCollection queryParams = ToArrayParameter("class_ids[]", class_ids);
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("archive_classes", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "archived"));
		}

		public int ReactivateClasses(int[] class_ids) {
			NameValueCollection queryParams = ToArrayParameter("class_ids[]", class_ids);
			Dictionary<string, object> response = (Dictionary<string, object>)Execute("reactivate_classes", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response,"reactivated"));
		}
		
		public void DeleteClasses(int[] class_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter("class_ids[]", class_ids));
			Execute("delete_classes", queryParams);
		}
		
		public void RestoreClasses(int[] class_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter("class_ids[]", class_ids));
			Execute("restore_classes", queryParams);
		}
				
	// class templates	

		public List<object> GetAllClassTemplates(int page) {
       			NameValueCollection queryParams = new NameValueCollection();
       			queryParams.Add("page", page.ToString());			
			return (List<object>) Execute("get_all_class_templates", queryParams);
	   	}

		public List<object> GetClassTemplatesWithIDs(int[] class_ids) {
			NameValueCollection queryParams = ToArrayParameter("class_ids[]", class_ids);
	     		return (List<object>) Execute("get_class_templates_with_ids", queryParams);
	   	}

		public List<object> GetClassTemplatesThatMatch(Dictionary<string, object> queryParamsDict, int page){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
	        	}
			queryParams.Add("page", page.ToString());
     	 		return (List<object>) Execute("get_class_templates_that_match", queryParams);
    		}
    
		public List<object> GetClassTemplatesForOrganization(int organization_id, int page) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("organization_id", organization_id.ToString());
			queryParams.Add("page", page.ToString());
			return (List<object>) Execute("get_class_templates_for_organization", queryParams);
	   	}

		public Dictionary<string, object> AddClassTemplate(Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection ();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			return (Dictionary<string, object>) Execute("add_class_template", queryParams);
		}

		public Dictionary<string, object> EditClassTemplate(int class_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection ();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("class_id", class_id.ToString());
			return (Dictionary<string, object>) Execute("edit_class_template", queryParams);
		}

		public void DeleteClassTemplates(int[] class_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter("class_ids[]", class_ids));
		   	Execute("delete_class_templates", queryParams);
	   	}
	
		public void RestoreClassTemplates(int[] class_ids) {
			NameValueCollection queryParams = new NameValueCollection();
		   	queryParams.Add(ToArrayParameter("class_ids[]", class_ids));
			Execute("restore_class_templates", queryParams);
	   	}
	
	// teachers

		public List<object> GetTeachersForClass(int class_id) {
      			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
      			return (List<object>) Execute("get_teachers_for_class", queryParams);
	    	}

	  	public int AddTeachersToClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
			queryParams.Add (ToArrayParameter ("user_ids[]", user_ids));
	    		Dictionary<string, object> response = (Dictionary<string, object>) Execute("add_teachers_to_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "enrolled"));
	  	}

	  	public int RemoveTeachersFromClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			queryParams.Add(ToArrayParameter("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("remove_teachers_from_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "unenrolled"));
	  	}
		      
	  	public List<object> GetClassesTaughtBy(int user_id) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("user_id", user_id.ToString());
	   	 	return (List<object>) Execute("get_classes_taught_by", queryParams);
	  	}

	  	public List<object> GetClassesEnrolledBy(int user_id) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("user_id", user_id.ToString());
      			return (List<object>) Execute("get_classes_enrolled_by", queryParams);
	  	}

	// students 

    		public List<object> GetStudentsForClass(int class_id) {
      			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
      			return (List<object>) Execute("get_students_for_class", queryParams);
    		}

	  	public int AddStudentsToClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			queryParams.Add(ToArrayParameter("user_ids[]", user_ids));
	    		Dictionary<string, object> response = (Dictionary<string, object>) Execute("add_students_to_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "enrolled"));
	  	}

	  	public int RemoveStudentsFromClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("remove_students_from_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "unenrolled"));
	  	}

	  	public int DeactivateStudentsInClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("deactivate_students_in_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "deactivated"));
	  	}

	  	public int ReactivateStudentsInClass(int class_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("reactivate_students_in_class", queryParams);
			return Convert.ToInt32(EnsureValueFromDictionary(response, "reactivated"));
	  	}
	// get_status_of_classes

	  	public List<object> GetStatusOfClasses(int user_id) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("user_id", user_id.ToString());
	    		return (List<object>) Execute("get_status_of_classes", queryParams);
	  	}

	// groups

	 	 public List<object> GetAllGroups(int page) {
	    		NameValueCollection queryParams = new NameValueCollection();
    			queryParams.Add("page", page.ToString());
	    		return (List<object>) Execute("get_all_groups", queryParams);
	  	}

	  	public List<object> GetGroupsWithIds(int[] group_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter ("group_ids[]", group_ids));
			return (List<object>) Execute("get_groups_with_ids", queryParams);
	  	}

		public List<object> GetGroupsThatMatch(Dictionary<string, object> queryParamsDict, int page) {
		  	NameValueCollection queryParams = new NameValueCollection ();
			
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("page", page.ToString());
	    		return (List<object>) Execute("get_groups_that_match", queryParams);
	  	}

	// add_group

		public Dictionary<string, object> AddGroup(Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			return (Dictionary<string, object>) Execute("add_group", queryParams);
		}

	// edit_group

		public Dictionary<string, object> EditGroup(int group_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("group_id", group_id.ToString());
			return (Dictionary<string, object>) Execute("edit_group", queryParams);
		}

	// delete_groups

		public void DeleteGroups(int[] group_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add(ToArrayParameter ("group_ids[]", group_ids));
			Execute("delete_groups", queryParams);
		}

	// group members
    
	  	public List<object> GetMembersForGroup(int group_id) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
	    		return (List<object>) Execute("get_members_for_group", queryParams);
	  	}

	  	public void AddMembersToGroup(int group_id, int[] user_ids) {
	    		NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
	    		Execute("add_members_to_group", queryParams);
	  	}

		public void RemoveMembersFromGroup(int group_id, int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Execute("remove_members_from_group", queryParams);
		}

		public List<object> GetGroupsWithMember(int user_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("user_id", user_id.ToString());
			return (List<object>) Execute("get_groups_with_member", queryParams);
		}

	// group admins
    
		public List<object> GetAdminsForGroup(int group_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
			return (List<object>) Execute("get_admins_for_group", queryParams);
		}

		public void AddAdminsToGroup(int group_id, int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Execute("add_admins_to_group", queryParams);
		}

		public void RemoveAdminsFromGroup(int group_id, int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("group_id", group_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Execute("remove_admins_from_group", queryParams);
		}

		public List<object> GetGroupsWithAdmin(int user_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("user_id", user_id.ToString());
			return (List<object>) Execute("get_groups_with_admin", queryParams);
		}

	// get_resources

		public List<object> GetResources(Dictionary<string, object> queryParamsDict, int page) {
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add(queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add("page", page.ToString());
			return (List<object>) Execute("get_resources", queryParams);
		}

	// organizations

		public List<object> GetAllOrganizations(int page) {
			NameValueCollection queryParams = new NameValueCollection();
    			queryParams.Add("page", page.ToString());	
			return (List<object>) Execute("get_all_organizations", queryParams);
		}

		public List<object> GetOrganizationsWithIds(int[] organization_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			string organization_ids_string = "";
			for (int i = 0; i < organization_ids.Length; i++) {
				if (i > 0) {
					organization_ids_string += "&organization_ids[]=";
				}
				organization_ids_string += organization_ids [i];
			}

			queryParams.Add ("organization_ids[]", organization_ids_string);
			return (List<object>) Execute("get_organizations_with_ids", queryParams);
		}

	// add_organization

		public Dictionary<string, object> AddOrganization(Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add (queryParam.Key, queryParam.Value.ToString());
			}
			return (Dictionary<string, object>) Execute("add_organization", queryParams);
		}

	// edit_organization

		public Dictionary<string, object> EditOrganization(int organization_id, Dictionary<string, object> queryParamsDict){
			NameValueCollection queryParams = new NameValueCollection();
			
			foreach (var queryParam in queryParamsDict) {
				queryParams.Add (queryParam.Key, queryParam.Value.ToString());
			}
			queryParams.Add ("organization_id", organization_id.ToString());
			return (Dictionary<string, object>) Execute("edit_organization", queryParams);
		}

	// delete_organizations

		public void DeleteOrganizations(int[] organization_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			string organization_ids_string = "";
			for (int i = 0; i < organization_ids.Length; i++) {
				if (i > 0) {
					organization_ids_string += "&organization_ids[]=";
				}
				organization_ids_string += organization_ids [i];
			}

			queryParams.Add ("organization_ids[]", organization_ids_string);
			return (List<object>) Execute("delete_organizations", queryParams);
		}



  	// paths

		public List<object> GetAllPaths(int page) {
		  	NameValueCollection queryParams = new NameValueCollection();
    			queryParams.Add("page", page.ToString());
			return (List<object>) Execute("get_all_paths", queryParams);
		}

		public List<object> GetPathsWithIds(int[] path_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			
			foreach(var path_id in path_ids){
				queryParams.Add("path_ids[]", path_id.ToString());
			}
			return (List<object>) Execute("get_paths_with_ids", queryParams);
		}

		public List<object> GetAdminsForPath(int path_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("path_id", path_id.ToString());
			return (List<object>) Execute("get_admins_for_path", queryParams);
		}

		public List<object> GetStudentsForPath(int path_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("path_id", path_id.ToString());
			return (List<object>) Execute("get_students_for_path", queryParams);
		}

		public int AddStudentsToPath(int path_id, int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("path_id", path_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("add_students_to_path", queryParams);
		  	return Convert.ToInt32(EnsureValueFromDictionary(response, "enrolled"));
		}

		public int RemoveStudentsFromPath(int path_id, int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("path_id", path_id.ToString());
			queryParams.Add(ToArrayParameter ("user_ids[]", user_ids));
			Dictionary<string, object> response = (Dictionary<string, object>) Execute("remove_students_from_path", queryParams);
		  	return Convert.ToInt32(EnsureValueFromDictionary(response, "unenrolled"));
		}

	// certificates

		public List<object> GetAllCertificates() {
			return (List<object>) Execute("get_all_certificates");
		}

		public List<object> GetCertificatesWithIds(int[] certificate_ids) {
			NameValueCollection queryParams = new NameValueCollection();
		
		  	foreach(var certificate_id in certificate_ids){
				queryParams.Add("certificate_ids[]", certificate_id.ToString());
			}
			return (List<object>) Execute("get_certificates_with_ids", queryParams);
		}

	// curricula

		public List<object> GetAllCurricula() {
			return (List<object>) Execute("get_all_curricula");
		}

		public List<object> GetCurriculaWithIds(int[] curriculum_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			
			foreach(var curriculum_id in curriculum_ids){
				queryParams.Add("curriculum_ids[]", curriculum_id.ToString());
			}
			return (List<object>) Execute("get_curricula_with_ids", queryParams);
		}

		public List<object> GetProficienciesForCurriculum(int curriculum_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("curriculum_id", curriculum_id.ToString());
			return (List<object>) Execute("get_proficiencies_for_curriculum", queryParams);
		}

	// lessons

		public List<object> GetLessonsForClass(int class_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			return (List<object>) Execute("get_lessons_for_class", queryParams);
		}

	// assignments

		public List<object> GetAssignmentsForClass(int class_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			return (List<object>) Execute("get_assignments_for_class", queryParams);
		}

	// grades
		
		public List<object> GetGradesForClass(int class_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("class_id", class_id.ToString());
			return (List<object>) Execute("get_grades_for_class", queryParams);
		}


	// get_grades_for_user

		public List<object> GetGradesForUser(int user_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("user_id", user_id.ToString());
			return (List<object>) Execute("get_grades_for_user", queryParams);
		}

		public Dictionary<string, object> SetGradesForAssignment(int assignment_id, Dictionary<string, object>[] grades) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add("assignment_id", assignment_id.ToString());

			List<string> gradesJSONList = new List<string>();

			foreach (var grade in grades) {
				gradesJSONList.Add(fastJSON.JSON.ToJSON (grade));
			}
			queryParams.Add (ToArrayParameter ("grades[]", gradesJSONList.ToArray()));
			return (Dictionary<string, object>) Execute("set_grades_for_assignment", queryParams);
		}

	// mastery


		public List<object> GetMasteryForClass(int class_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
			return (List<object>) Execute("get_mastery_for_class", queryParams);
		}

	// attendance

		public List<object> GetAllAttendance(int class_id) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
			return (List<object>) Execute("get_all_attendance", queryParams);
		}

		public List<object> GetAttendance(int class_id, DateTime date_and_time) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
			queryParams.Add ("date_and_time", date_and_time.ToString());
			return (List<object>) Execute("get_attendance", queryParams);
		}

	// news feeds

		public int PostClassAnnouncement(int class_id, string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("class_id", class_id.ToString());
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_class_announcement", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}

		public int PostClassMessage(int class_id, string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("class_id", class_id.ToString());
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_class_message", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}

		public int PostGroupAnnouncement(int group_id, string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("group_id", group_id.ToString());
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_group_announcement", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}

		public int PostGroupMessage(int group_id, string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("group_id", group_id.ToString());
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_group_message", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}

		public int PostSiteAnnouncement(string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_site_announcement", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}

		public int PostSiteMessage(string message, Dictionary<string, object> options) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add ("message", message);
				queryParams = MergeOptionsToParams(queryParams, options);
				Dictionary<string, object> response = (Dictionary<string, object>) Execute("post_site_message", queryParams);
				return Convert.ToInt32(EnsureValueFromDictionary(response, "posted"));
		}
      
	// games
		
		public List<object> GetGamesForSite() {
				return (List<object>) Execute("get_games_for_site");
		}
		 
		public List<object> GetGamesForClass(int class_id) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add("class_id", class_id.ToString());
				return (List<object>) Execute("get_games_for_class", queryParams);
		} 
		
		public List<object> GetStatusForAllPlayers(int game_id) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add("game_id", game_id.ToString());
				return (List<object>) Execute("get_status_for_all_players", queryParams);
		} 	   
		 
		public List<object> GetStatusForPlayers(int game_id, int[] user_ids) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add("game_id", game_id.ToString());
		
				foreach(var user_id in user_ids){
					queryParams.Add ("user_ids[]", user_id.ToString());
				}	        
				return (List<object>) Execute("get_status_for_players", queryParams);
		}	        
	      	    
	// sessions

		public List<object> GetSessionDetails(int[] user_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			
			foreach(var user_id in user_ids){
				queryParams.Add ("user_ids[]", user_id.ToString());
			}
			return (List<object>) Execute("get_session_details", queryParams);
		}

	// reports

		public List<object> GetClassReport(int class_id, Dictionary<string, object> conditions) {
			NameValueCollection queryParams = new NameValueCollection();
			queryParams.Add ("class_id", class_id.ToString());
			queryParams = MergeOptionsToParams(queryParams, conditions);
			return (List<object>) Execute("get_class_report", queryParams);
		}

	// e-commerce

		public List<object> GetAllOrders() {
				return (List<object>) Execute("get_all_orders");
		}

		public List<object> GetOrdersWithIds(int[] order_ids) {
			NameValueCollection queryParams = new NameValueCollection();
			
			foreach(var order_id in order_ids){
				queryParams.Add ("order_ids[]", order_id.ToString());
			}
			return (List<object>) Execute("get_orders_with_ids", queryParams);
		}

		public List<object> GetOrdersForOrganization(int organization_id) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add("organization_id", organization_id.ToString());
				return (List<object>) Execute("get_orders_for_organization", queryParams);
		} 

		public List<object> GetOrdersForUser(int user_id) {
				NameValueCollection queryParams = new NameValueCollection();
				queryParams.Add("user_id", user_id.ToString());
				return (List<object>) Execute("get_orders_for_user", queryParams);
		} 		 

////

		private object Execute(string path, NameValueCollection queryParams = null){
			string rawResponse = this.Get (path, queryParams);
			return fastJSON.JSON.Parse (rawResponse);
		}

		private string Get(string path, NameValueCollection queryParams)
		{
			string url = this.host + "/api/" + path;

			WebClient webClient = new WebClient ();
			webClient.QueryString.Add ("api_key", api_key);

			if (queryParams != null)
				webClient.QueryString.Add (queryParams);

			try {
				return webClient.DownloadString (url);
			} catch (Exception ex) {
				throw new ApiException ("Cypherlearning Exception", ex);
			}
		}

		private object EnsureValueFromDictionary(Dictionary<string, object> dictionary, string key){
			if (dictionary.ContainsKey (key)) {
				return dictionary [key];
			} else {
				string message = "An unknown error happened";
				if(dictionary.ContainsKey("message"))
					message = dictionary ["message"].ToString();
				throw new ApiException (message.ToString());
			}
		}

		private NameValueCollection MergeOptionsToParams(NameValueCollection nameValueCollection, Dictionary<string, object> paramsToAdd){
			NameValueCollection results = new NameValueCollection (nameValueCollection);
			if (paramsToAdd != null) {
				foreach (KeyValuePair<string, object> entry in paramsToAdd) {
					results.Add (entry.Key, entry.Value.ToString ());
				}
			}
			return results;
		}

		private NameValueCollection ToArrayParameter(string paramName, int[] items){
			string[] stringArray = new string[items.Length];
			for (int i = 0; i < items.Length; i++) {
				stringArray [i] = items [i].ToString ();
			}
			return ToArrayParameter (paramName, stringArray);
		}

		private NameValueCollection ToArrayParameter(string paramName, string[] items){
			string paramString = "";
			for (int i = 0; i < items.Length; i++) {
				if (i > 0) {
					paramString += "&" + paramName + "=";
				}
				paramString += items [i];
			}
			return new NameValueCollection { { paramName, paramString } };
		}
	}
}
