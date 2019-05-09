using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace csharpapiclient
{
	class MainClass
	{
		public static void Main (string[] args)
		{	
			Api api_client = new Api("http://sandbox.example.com", "YOUR_API_KEY");
			Console.WriteLine ("Get version" + api_client.GetVersion ());
			Console.WriteLine ("Is Authenticated: " + api_client.IsAuthenticated ("attila", "123456"));
			Console.WriteLine ("Get my account: "+ fastJSON.JSON.ToJSON(api_client.GetMyAccount ()));
			Console.WriteLine ("Get all users: " + api_client.GetAllUsers().Count);
			Console.WriteLine ("Get users with ids: " + api_client.GetUsersWithIds (new int[]{ 162919, 163097 }).Count);
			Dictionary<string, object> userMatchParams = new Dictionary<string, object>();
			userMatchParams.Add("userid", "S1X");
			Console.WriteLine ("Get users that match: " + fastJSON.JSON.ToJSON(api_client.GetUsersThatMatch(userMatchParams)));
			Dictionary<string, object> userParams = new Dictionary<string, object>();
			userParams.Add ("first_name", "John");
			userParams.Add ("last_name", "Doe");
			userParams.Add ("account_types", "student");
            userParams.Add("userid", "student123");

            // classes TO DO

            Console.WriteLine ("Add user: " + fastJSON.JSON.ToJSON(api_client.AddUser(userParams)));
            Dictionary<string, object> userParams2 = new Dictionary<string, object>();
            userParams2.Add("first_name", "Dave");
            userParams2.Add("last_name", "Dave");
            userParams2.Add("account_types", "student");
            userParams2.Add("userid", "student123");
            Console.WriteLine("Update user: " + fastJSON.JSON.ToJSON(api_client.UpdateUser(userParams2)));
            Console.WriteLine ("Archive user: " + api_client.ArchiveStudents(new int[]{249433, 163097}));
			Console.WriteLine ("Reactivate user: " + api_client.ReactivateStudents(new int[]{249433, 163097}));
			Console.WriteLine ("Get all classes: " + api_client.GetAllClasses().Count);
			Console.WriteLine ("Get all archived classes: " + api_client.GetArchivedClasses().Count);
			Console.WriteLine ("Get classes with IDs: " + api_client.GetClassesWithIDs(new int[]{18675, 18689}).Count);
			Console.WriteLine ("Get classes for Organization:  " + api_client.GetClassesForOrganization(4404).Count);
			Console.WriteLine ("Get classes that match:  " + api_client.GetClassesThatMatch(new Dictionary<string, object>()).Count);

			Console.WriteLine ("Get classes taught by:  " + api_client.GetClassesTaughtBy(249433).Count);
			Console.WriteLine ("Get classes enrolled by:  " + api_client.GetClassesEnrolledBy(249433).Count);

	    Console.WriteLine("Get teachers for class:  " + api_client.GetTeachersForClass(27919).Count);
	    Console.WriteLine("Get students for class:  " + api_client.GetStudentsForClass(27919).Count);
	        try {
				Console.WriteLine("Add students to class:  " + api_client.AddStudentsToClass(18675, new int[]{249380, 163097}));
	        }catch (ApiException e){
				StreamReader responseBody = new StreamReader (e.Response.GetResponseStream ());
				Console.WriteLine("An exception occurred" + responseBody.ReadToEnd());
	        }

			Console.WriteLine("Remove students from class:  " + api_client.RemoveStudentsFromClass(18675, new int[]{249380, 163097}));
	    Console.WriteLine("Get status of classes:  " + fastJSON.JSON.ToJSON(api_client.GetStatusOfClasses(249380))); // get_status_of_classes

      // groups
      
	    Console.WriteLine("Get All groups " + api_client.GetAllGroups().Count);
			Console.WriteLine("Get All groups with ids" + api_client.GetGroupsWithIds(new int[]{3486}).Count);
	        Dictionary<string, object> groupsMatchParams = new Dictionary<string, object>();
	        groupsMatchParams.Add ("name", "Test");
	        Console.WriteLine("Get groups that match: " + api_client.GetGroupsThatMatch(groupsMatchParams).Count);
	        Console.WriteLine("Get members for group: " + api_client.GetMembersForGroup(3486).Count);
	        api_client.AddMembersToGroup(3486, new int[]{162919});
	        api_client.AddAdminsToGroup(3486, new int[]{162919});

			Console.WriteLine("getAdminsForGroup: " + api_client.GetAdminsForGroup(3486).Count);
			Console.WriteLine("getGroupsWithMember" + api_client.GetGroupsWithMember(162919).Count);
			Console.WriteLine("getGroupsWithAdmin" + api_client.GetGroupsWithAdmin(162919).Count);

	        api_client.RemoveAdminsFromGroup(3486, new int[]{162919});
	        api_client.RemoveMembersFromGroup(3486, new int[]{162919});

	    Dictionary<string, object> groupParams = new Dictionary<string, object>();
			groupParams.Add ("name", "newGroupAPIC#");
			Console.WriteLine ("Add group: " + fastJSON.JSON.ToJSON(api_client.AddGroup(groupParams))); // add_group

      Dictionary<string, object> editgroupParams = new Dictionary<string, object>();
			editgroupParams.Add ("name", "newGroupAPIC#22");
			Console.WriteLine ("Edit group: " + fastJSON.JSON.ToJSON(api_client.EditGroup(8750,editgroupParams))); // edit_group

			Console.WriteLine("Delete groups with ids: " + api_client.DeleteGroups(new int[]{9871})); // delete_groups

      // resources
      
			Dictionary<string, object> resource_type = new Dictionary<string, object>();
			resource_type.Add ("type",'File');
			Console.WriteLine("Get resources: " + api_client.GetResources(resource_type).Count); // get_resources

      // organizations 
      
			Console.WriteLine("getAllOrganizations: "+ api_client.GetAllOrganizations().Count);
			Console.WriteLine("getOrganizationsWithIDs: "+ fastJSON.JSON.ToJSON(api_client.GetOrganizationsWithIds(new int[]{4404, 8099})));

			Dictionary<string, object> organizationParams = new Dictionary<string, object>();
      organizationParams.Add ("name", "newORGAPIC#");
      Console.WriteLine ("Add organization: " + fastJSON.JSON.ToJSON(api_client.AddOrganization(organizationParams))); // add_organization

      Dictionary<string, object> editorganizationParams = new Dictionary<string, object>();
      editorganizationParams.Add ("name", "newOrganizationAPIC#22");
      Console.WriteLine ("Edit organization: " + fastJSON.JSON.ToJSON(api_client.EditOrganization(8099,editorganizationParams))); // edit_organization

      Console.WriteLine("Delete organizations with ids: " + api_client.DeleteOrganizations(new int[]{26517})); // delete_organizations

      // paths TO DO
      
			Console.WriteLine("GetAllPaths: "+ api_client.GetAllPaths().Count); // get_all_paths
			Console.WriteLine("GetPathsWithIds: "+ api_client.GetPathsWithIds(new int[]{191, 192}).Count);  // get_paths_with_ids
      
      // certificates
      
			Console.WriteLine("getAllCertificates: "+ api_client.GetAllCertificates().Count);
			Console.WriteLine("getCertificatesWithIDs: "+ api_client.GetCertificatesWithIds(new int[]{1318, 1342}).Count);
      
      // curricula
      
 			Console.WriteLine("GetAllCurricula: "+ api_client.GetAllCurricula().Count);  						// get_all_curriculla
 			Console.WriteLine("GetCurriculaWithIds: "+ api_client.GetCurriculaWithIds(new int[]{915, 3949}).Count); // get_curricula_with_ids
 			Console.WriteLine("GetProficienciesForCurriculum: "+ api_client.GetProficienciesForCurriculum(915).Count); //get_proficiencies_for_curriculum

			// lessons			
			Console.WriteLine("getLessonsForClass: " + api_client.GetLessonsForClass(18675).Count);
			
			// assignments
			Console.WriteLine("getAssignmentsForClass: " + api_client.GetAssignmentsForClass(18675).Count);
			
			// grades
			Console.WriteLine("getGradesForClass: " + api_client.GetGradesForClass(18675).Count);
			Console.WriteLine("getGradesForUser: " + api_client.GetGradesForUser(249380).Count); // get_grades_for_user

			Dictionary<string, object> grade1 = new Dictionary<string, object>();
			grade1.Add ("user_id",249380);
			grade1.Add ("grade", "A");
			Dictionary<string, object> grade2 = new Dictionary<string, object>();
			grade2.Add ("user_id",287224);
			grade2.Add ("grade", "B");
			Dictionary<string, object>[] grades = new Dictionary<string, object>[] { grade1, grade2 };
			try{
				Console.WriteLine("setGradesForAssignment: " + fastJSON.JSON.ToJSON(api_client.SetGradesForAssignment(79063, grades)));
			}catch (ApiException e){
				Console.WriteLine("An exception occurred" + e);
			}

			// attendance

			Console.WriteLine("getAllAttendance: " + api_client.GetAllAttendance(18675).Count);
			Console.WriteLine("getAttendance: "+ fastJSON.JSON.ToJSON(api_client.GetAttendance(18675, new DateTime())));

			// news feeds

			Console.WriteLine("postClassAnnouncement: "+ api_client.PostClassAnnouncement(18675, "Class announcement", null));
			Console.WriteLine("postClassMessage: "+ api_client.PostClassMessage(18675, "Class message", null));
			Console.WriteLine("postGroupAnnouncement: "+ api_client.PostGroupAnnouncement(3486, "Group announcement", null));
			Console.WriteLine("postGroupMessage: "+ api_client.PostGroupMessage(3486, "Group message", null));
			Console.WriteLine("postSiteAnnouncement: "+ api_client.PostSiteAnnouncement("Site announcement", null));
			Console.WriteLine("postSiteMessage: "+ api_client.PostSiteMessage("Site message", null));

			// games TO DO
			
			// sessions
			Console.WriteLine("getSessionDetails: "+ fastJSON.JSON.ToJSON(api_client.GetSessionDetails(new int[]{314432})));
			
			// reports
			Dictionary<string, object> conditions = new Dictionary<string, object>();
			conditions.Add ("student_ids", new int[]{249380, 163097});
			DateTime fromDate = new DateTime (2015, 10, 16, 00, 13, 14);
			DateTime toDate = new DateTime (2015, 10, 20, 00, 13, 14);
			conditions.Add ("from", fromDate.ToString("yyyy-MM-dd HH:mm:ss"));
			conditions.Add ("to", toDate.ToString("yyyy-MM-dd HH:mm:ss"));

			Console.WriteLine("getClassReport: " + fastJSON.JSON.ToJSON(api_client.GetClassReport(18675, conditions)));
		}
	}
}
