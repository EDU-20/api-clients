package main.java.com.cypherlearning.client;

import main.java.com.cypherlearning.client.exception.ApiException;


import java.io.IOException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class Example

{
    public static void main( String[] args ) throws ApiException, ParseException {
		Api api_client = new Api("http://sandbox.example.com", "YOUR_API_KEY");

        System.out.println("Api version: " + api_client.getVersion());
        System.out.println("Is Authenticated: " + api_client.isAuthenticated("username", "123456"));
        System.out.println("Get my account: " + api_client.getMyAccount());
        System.out.println("Get all users: " + api_client.getAllUsers());
        System.out.println("Get users with ids: " + api_client.getUsersWithIds(new int[]{162919, 162920}));
        Map<String, Object> userMatchParams = new HashMap<String, Object>();
        userMatchParams.put("userid", "S1X");
        System.out.println("Get users that match: " + api_client.getUsersThatMatch(userMatchParams));

        Map<String, Object> userParams = new HashMap<String, Object>();
        userParams.put("first_name", "John");
        userParams.put("last_name", "Doe");
        userParams.put("account_types", "student");

        System.out.println("Add user: " + api_client.addUser(userParams));
        System.out.println("Archive user: " + api_client.archiveStudents(new int[]{249433}));
        System.out.println("Reactivate user: " + api_client.reactivateStudents(new int[]{249433}));

    // classes TO DO
    
        System.out.println("Get all classes: " + api_client.getAllClasses().size());
        System.out.println("Get all archived classes: " + api_client.getArchivedClasses().size());
        System.out.println("Get classes with IDs: " + api_client.getClassesWithIDs(new int[]{18675}).size());
        System.out.println("Get classes for Organization:  " + api_client.getClassesForOrganization(4404).size());
        System.out.println("Get classes that match:  " + api_client.getClassesThatMatch(new HashMap<String, Object>()).size());

        System.out.println("Get classes taught by:  " + api_client.getClassesTaughtBy(249433).size());
        System.out.println("Get classes enrolled by:  " + api_client.getClassesEnrolledBy(249433).size());

        System.out.println("Get teachers for class:  " + api_client.getTeachersForClass(27919).size());
        System.out.println("Get students for class:  " + api_client.getStudentsForClass(27919).size());
        try {
            System.out.println("Add students to class:  " + api_client.addStudentsToClass(18675, new int[]{249380})); // new int[]{249380, 287224}
        }catch (ApiException e){
            System.out.println("An exception occurred" + e);
        }
        
        System.out.println("Remove students from class:  " + api_client.removeStudentsFromClass(27919, new int[]{249433}));
	      System.out.println("Get status of classes :  " +api_client.getStatusOfClasses(249380).size()); //get_status_of_classes

        System.out.println("Get All groups " + api_client.getAllGroups().size());
        System.out.println("Get All groups with ids" + api_client.getGroupsWithIds(new int[]{3486}));
        Map<String, Object> groupsMatchParams = new HashMap<String, Object>();
        groupsMatchParams.put("name", "Test");
        System.out.println("Get groups that match: " + api_client.getGroupsThatMatch(groupsMatchParams).size());
        System.out.println("Get members for group: " + api_client.getMembersForGroup(3486).size());
        api_client.addMembersToGroup(3486, new int[]{162919});
        api_client.removeMembersFromGroup(3486, new int[]{162919});
        api_client.addAdminsToGroup(3486, new int[]{162919});
        api_client.removeAdminsFromGroup(3486, new int[]{162919});

        System.out.println("getAdminsForGroup: " + api_client.getAdminsForGroup(3486));
        System.out.println("getGroupsWithMember" + api_client.getGroupsWithMember(162919));
        System.out.println("getGroupsWithAdmin" + api_client.getGroupsWithAdmin(162919));

        Map<String, Object> newgroupsParams = new HashMap<String, Object>();
        newgroupsParams.put("name", "Test-JavaAPI");
	      System.out.println("add Group"+api_client.addGroup(newgroupsParams)); //add_group

        Map<String, Object> editgroupsParams = new HashMap<String, Object>();
        editgroupsParams.put("name", "Test-JavaAPI22");
	      System.out.println("edit Group" + api_client.editGroup(8750,editgroupsParams)); //edit_group

	      System.out.println("delete Group with ids" + api_client.deleteGroups(new int[]{9871})); //delete_groups

        Map<String, Object> resourcestype = new HashMap<String, Object>();
        resourcestype.put("type", "File");
	      System.out.println("get Resources" + api_client.getResources(resourcestype)); //get_resources

        System.out.printf("getAllOrganizations: "+ api_client.getAllOrganizations());
        System.out.printf("getOrganizationsWithIDs: "+ api_client.getOrganizationsWithIds(new int[]{4404, 8099}));

        Map<String, Object> neworgParams = new HashMap<String, Object>();
        neworgParams.put("name", "Test-Org-JavaAPI");
	      System.out.println("add Organization"+api_client.addOrganization(neworgParams)); //add_organization

        Map<String, Object> editorganizationParams = new HashMap<String, Object>();
        editorganizationParams.put("name", "Test-Org-JavaAPI22");
	      System.out.println("edit Organization" + api_client.editOrganization(8099,editorganizationParams)); //edit_organization

      	System.out.println("delete Organizations with ids" + api_client.deleteOrganizations(new int[]{26517})); //delete_organizations
 
   	// paths TO DO
 
        System.out.printf("getAllPaths: "+ api_client.getAllPaths());
        System.out.printf("getPathsWithIds: "+ api_client.getPathsWithIds(new int[]{192}));
            
        System.out.printf("getAllCertificates: "+ api_client.getAllCertificates());
        System.out.printf("getCertificatesWithIDs: "+ api_client.getCertificatesWithIds(new int[]{1318}));

	  // curricula

        System.out.println("getAllCurricula: " + api_client.getAllCurricula());
        System.out.println("getCurriculaWithIds: "+ api_client.getCurriculaWithIds(new int[]{915,3949}));
        System.out.println("getProficienciesForCurriculum: "+ api_client.getProficienciesForCurriculum(915));

        System.out.println("getLessonsForClass: " + api_client.getLessonsForClass(18675));
        System.out.println("getAssignmentsForClass: " + api_client.getAssignmentsForClass(18675));
        System.out.println("getGradesForClass: " + api_client.getGradesForClass(18675));
        System.out.println("getGradesForUser: " + api_client.getGradesForUser(249380)); //get_grades_for_user 
        
        Map grade1 = new HashMap<String, Object>();
        grade1.put("user_id",249380);
        grade1.put("grade", "A");
        Map grade2 = new HashMap();
        grade2.put("user_id",287224);
        grade2.put("grade", "B");
        Map[] grades = {grade1, grade2};
        System.out.println("setGradesForAssignment: " + api_client.setGradesForAssignment(79063, grades));
        
        System.out.println("getAllAttendance: " + api_client.getAllAttendance(18675));
        System.out.println("getAttendance: "+ api_client.getAttendance(18675, new Date()));
        
        System.out.println("postClassAnnouncement: "+ api_client.postClassAnnouncement(18675, "Class announcement", null));
        System.out.println("postClassMessage: "+ api_client.postClassMessage(18675, "Class message", null));
        System.out.println("postGroupAnnouncement: "+ api_client.postGroupAnnouncement(3486, "Group announcement", null));
        System.out.println("postGroupMessage: "+ api_client.postGroupMessage(3486, "Group message", null));
        System.out.println("postSiteAnnouncement: "+ api_client.postSiteAnnouncement("Site announcement", null));
        System.out.println("postSiteMessage: "+ api_client.postSiteMessage("Site Message", null));

    // games TO DO       

        System.out.printf("getSessionDetails: "+ api_client.getSessionDetails(new int[]{314432}));
        Map conditions = new HashMap();
        conditions.put("student_ids", new int[]{249380});
        DateFormat simpleDateFormat = new SimpleDateFormat( "yyyy-MM-dd HH:mm:ss" );
        conditions.put("from", simpleDateFormat.parse("2015-10-16 00:13:14"));
        conditions.put("to", simpleDateFormat.parse("2015-10-20 00:13:14"));

        System.out.printf("getClassReport: " + api_client.getClassReport(18675, conditions));

        try {
            api_client.shutdown();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
