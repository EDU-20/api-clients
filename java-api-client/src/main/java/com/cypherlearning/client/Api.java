package com.cypherlearning.client;

import com.cypherlearning.client.exception.ApiException;
import com.mashape.unirest.http.*;
import com.mashape.unirest.http.exceptions.UnirestException;
import com.mashape.unirest.request.GetRequest;
import org.json.JSONArray;
import org.json.JSONObject;


import java.io.IOException;
import java.util.*;


public class Api {
	public final String host;
	public final String api_key;

	public Api(String host, String api_key) {
		this.host = host;
		this.api_key = api_key;
	}

	public int getVersion() throws ApiException {
        	Map response = (Map)this.execute("get_version");
        	return (Integer) ensureValueFromMap(response, "version");
	}

    	public boolean isAuthenticated(String userid, String password) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("userid", userid);
        	params.put("password", password);
        	Map response = (Map)this.execute("is_authenticated", params);
        	return (Boolean) ensureValueFromMap(response, "authenticated");
    	}

    	public Map getMyAccount() throws ApiException {
        	return (Map)this.execute("get_my_account");
    	}

	// users

    	public ArrayList getAllUsers(int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_users", params);
    	}

    	public ArrayList getUsersWithIds(int[] user_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("user_ids[]", user_ids);
        	return (ArrayList)this.execute("get_users_with_ids", params);
    	}

    	public ArrayList getUsersThatMatch(Map<String, Object> params, int page) throws ApiException{
        	params.put("page", page);
        	return (ArrayList)this.execute("get_users_that_match", params);
    	}

    	public Map addUser(Map<String, Object> params) throws ApiException{
        	return (Map)this.execute("add_user", params);
    	}

    	public int archiveStudents(int[] student_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_ids[]", student_ids);
        	Map response = (Map)this.execute("archive_students", params);
        	return (Integer) ensureValueFromMap(response, "archived");
    	}

    	public int reactivateStudents(int[] student_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_ids[]", student_ids);
        	Map response = (Map)this.execute("reactivate_students", params);
        	return (Integer) ensureValueFromMap(response,"reactivated");
    	}

	// classes

    	public ArrayList getAllClasses(int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_classes", params);
    	}

    	public ArrayList getClassesWithIDs(int[] class_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_ids[]", class_ids);
        	return (ArrayList)this.execute("get_classes_with_ids", params);
    	}

    	public ArrayList getClassesThatMatch(Map<String, Object> params, int page) throws ApiException{
		params.put("page", page);
        	return (ArrayList)this.execute("get_classes_that_match", params);
    	}

    	public ArrayList getClassesForOrganization(int organization_id, int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("organization_id", organization_id);
		params.put("page", page);
        	return (ArrayList)this.execute("get_classes_for_organization", params);
    	}
    
    	public Map addClass(Map<String, Object> params) throws ApiException {
       		return (Map)this.execute("add_class", params);
    	}

   	public Map addClassFromTemplate(int class_template_id, Map<String, Object> params) throws ApiException {
        	params.put("class_template_id", class_template_id);
        	return (Map)this.execute("add_class_from_template", params);
    	}

   	public Map addChildClass(int parent_class_id, Map<String, Object> params) throws ApiException {
        	params.put("parent_class_id", parent_class_id);
       		return (Map)this.execute("add_child_class", params);
    	}

   	public Map editClass(int class_id, Map<String, Object> params) throws ApiException {
        	params.put("class_id", class_id);
        	return (Map)this.execute("edit_class", params);
    	}

    	public ArrayList getArchivedClasses(int page) throws ApiException {
        	HashMap<String, Object> params = new HashMap<String, Object>();
        	params.put("archived", true);
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_classes", params);
    	}
    
    	public int archiveClasses(int[] class_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_ids[]", class_ids);
        	Map response = (Map)this.execute("archive_classes", params);
        	return (Integer) ensureValueFromMap(response, "archived");
    	}    
    
    	public int reactivateClasses(int[] class_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_ids[]", class_ids);
        	Map response = (Map)this.execute("reactivate_classes", params);
        	return (Integer) ensureValueFromMap(response, "reactivated");
    	}   
    
    	public void deleteClasses(int[] class_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();     
        	params.put("class_ids[]", class_ids);
        	this.execute("delete_classes", params);
    	}
    
    	public void restoreClasses(int[] class_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();     
        	params.put("class_ids[]", class_ids);
        	this.execute("restore_classes", params);
    	}    


	// class templates

    	public ArrayList getAllClassTemplates(int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_class_templates", params);
    	}

    	public ArrayList getClassTemplatesWithIDs(int[] class_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_ids[]", class_ids);
        	return (ArrayList)this.execute("get_class_templates_with_ids", params);
    	}

    	public ArrayList getClassTemplatesThatMatch(Map<String, Object> params, int page) throws ApiException{
		params.put("page", page);
        	return (ArrayList)this.execute("get_class_templates_that_match", params);
    	}

    	public ArrayList getClassTemplatesForOrganization(int organization_id, int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
       		params.put("organization_id", organization_id);
		params.put("page", page);
        	return (ArrayList)this.execute("get_class_templates_for_organization", params);
    	}
    
   	public Map addClassTemplate(Map<String, Object> params) throws ApiException {
        	return (Map)this.execute("add_class_template", params);
    	}

   	public Map editClassTemplate(int class_id, Map<String, Object> params) throws ApiException   {
        	params.put("class_id", class_id);
        	return (Map)this.execute("edit_class_template", params);
    	}

    	public void deleteClassTemplates(int[] class_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();     
        	params.put("class_ids[]", class_ids);
       		this.execute("delete_class_templates", params);
    	}
    
    	public void restoreClassTemplates(int[] class_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();     
        	params.put("class_ids[]", class_ids);
        	this.execute("restore_class_templates", params);
    	}    

	//teachers

    	public ArrayList getTeachersForClass(int class_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList)this.execute("get_teachers_for_class", params);
    	}

    	public int addTeachersToClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("add_teachers_to_class", params);
       		return (Integer) ensureValueFromMap(response, "enrolled");
    	}

    	public int removeTeachersFromClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("remove_teachers_from_class", params);
        	return (Integer)ensureValueFromMap(response, "unenrolled");
    	}
    
    	public ArrayList getClassesTaughtBy(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList)this.execute("get_classes_taught_by", params);
    	}

    	public ArrayList getStudentsForClass(int class_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList)this.execute("get_students_for_class", params);
    	}

    	public int addStudentsToClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
       		params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("add_students_to_class", params);
        	return (Integer) ensureValueFromMap(response, "enrolled");
    	}

    	public int removeStudentsFromClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("remove_students_from_class", params);
        	return (Integer)ensureValueFromMap(response, "unenrolled");
    	}
    
   	public int deactivateStudentsInClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("deactivate_students_in_class", params);
        	return (Integer)ensureValueFromMap(response, "deactivated");
    	}

  	public int reactivateStudentsInClass(int class_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("reactivate_students_in_class", params);
        	return (Integer)ensureValueFromMap(response, "reactivated");
    	}

    	public ArrayList getClassesEnrolledBy(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList)this.execute("get_classes_enrolled_by", params);
    	}

	// get_status_of_classes(user_id)

    	public ArrayList getStatusOfClasses(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList)this.execute("get_status_of_classes", params);
    	}

	// groups

    	public ArrayList getAllGroups(int page) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList) this.execute("get_all_groups", params);
    	}

    	public ArrayList getGroupsWithIds(int[] group_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("group_ids[]", group_ids);
        	return (ArrayList)this.execute("get_groups_with_ids", params);
    	}

    	public ArrayList getGroupsThatMatch(Map<String, Object> params, int page) throws ApiException{
		params.put("page", page);
        	return (ArrayList)this.execute("get_groups_that_match", params);
    	}

	// add_group
    
    	public Map addGroup(Map<String, Object> params) throws ApiException{
        	return (Map)this.execute("add_group", params);
    	}
    
	// edit_group

    	public Map editGroup(int group_id, Map<String, Object> params) throws ApiException{
        	params.put("group_id", group_id);
        	return (Map)this.execute("edit_group", params);
    	}

	// delete_groups
 
    	public void deleteGroups(int[] group_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();     
        	params.put("group_ids[]", group_ids);
       		this.execute("delete_groups", params);
    	}

	// group members

    	public ArrayList getMembersForGroup(int group_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	return (ArrayList)this.execute("get_members_for_group", params);
    	}

    	public void addMembersToGroup(int group_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	params.put("user_ids[]", user_ids);
        	this.execute("add_members_to_group", params);
    	}

    	public void removeMembersFromGroup(int group_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	params.put("user_ids[]", user_ids);
        	this.execute("remove_members_from_group", params);
    	}

    	public ArrayList getGroupsWithMember(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList) this.execute("get_groups_with_member", params);
    	}

	// group admins

   	public ArrayList getAdminsForGroup(int group_id) throws ApiException {
       		Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	return (ArrayList)this.execute("get_admins_for_group", params);
    	}

    	public void addAdminsToGroup(int group_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	params.put("user_ids[]", user_ids);
        	this.execute("add_admins_to_group", params);
    	}

    	public void removeAdminsFromGroup(int group_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
       	 	params.put("user_ids[]", user_ids);
        	this.execute("remove_admins_from_group", params);
    	}

    	public ArrayList getGroupsWithAdmin(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList) this.execute("get_groups_with_admin", params);
    	}

	// get_resources

    	public ArrayList getResources(Map<String, Object> params, int page) throws ApiException{
   		params.put("page", page);
        	return (ArrayList)this.execute("get_resources", params);
    	}

	// organizations

    	public ArrayList getAllOrganizations(int page) throws ApiException {
		Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_organizations", params);
    	}

    	public ArrayList getOrganizationsWithIds(int[] organization_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("organization_ids[]", organization_ids);
        	return (ArrayList)this.execute("get_organizations_with_ids", params);
    	}

	// add_organization

    	public Map addOrganization(Map<String, Object> params) throws ApiException{
        	return (Map)this.execute("add_organization", params);
    	}

	// edit_organization

   	public Map editOrganization(int organization_id, Map<String, Object> params) throws ApiException{
        	params.put("organization_id", organization_id);
       		return (Map)this.execute("edit_organization", params);
    	}

	// delete_organizations

    	public void deleteOrganizations(int[] organization_ids) throws ApiException{
    		Map<String, Object> params = new HashMap<String, Object>();
        	params.put("organization_ids[]", organization_ids);
        	this.execute("delete_organizations", params);
    	}

	// paths

    	public ArrayList getAllPaths(int page) throws ApiException {
		Map<String, Object> params = new HashMap<String, Object>();
        	params.put("page", page);
        	return (ArrayList)this.execute("get_all_paths", params);
    	}

    	public ArrayList getPathsWithIds(int[] path_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("path_ids[]", path_ids);
        	return (ArrayList)this.execute("get_paths_with_ids", params);
    	}

    	public ArrayList getAdminForPath(int path_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("path_id", path_id);
        	return (ArrayList) this.execute("get_admins_for_path", params);
    	}

    	public ArrayList getStudentsForPath(int path_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("path_id", path_id);
        	return (ArrayList) this.execute("get_students_for_path", params);
    	}

    	public int addStudentsToPath(int path_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("path_id", path_id);
        	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("add_students_to_path", params);
        	return (Integer) ensureValueFromMap(response, "enrolled");
    	}

    	public int removeStudentsFromPath(int path_id, int[] user_ids) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("path_id", path_id);
       	 	params.put("user_ids[]", user_ids);
        	Map response = (Map)this.execute("remove_students_from_path", params);
        	return (Integer)ensureValueFromMap(response, "unenrolled");
    	}

	// certificates

    	public ArrayList getAllCertificates() throws ApiException {
        	return (ArrayList)this.execute("get_all_certificates");
    	}

    	public ArrayList getCertificatesWithIds(int[] certificate_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("certificate_ids[]", certificate_ids);
        	return (ArrayList)this.execute("get_certificates_with_ids", params);
    	}

	// curricula

    	public ArrayList getAllCurricula() throws ApiException {
        	return (ArrayList)this.execute("get_all_curricula");
    	}

    	public ArrayList getCurriculaWithIds(int[] curriculum_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("curriculum_ids[]", curriculum_ids);
        	return (ArrayList)this.execute("get_curricula_with_ids", params);
    	}

    	public ArrayList getProficienciesForCurriculum(int curriculum_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("curriculum_id", curriculum_id);
        	return (ArrayList)this.execute("get_proficiencies_for_curriculum", params);
    	}

	// lessons

    	public ArrayList getLessonsForClass(int class_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList) this.execute("get_lessons_for_class", params);
    	}

	// assignments

    	public ArrayList getAssignmentsForClass(int class_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList) this.execute("get_assignments_for_class", params);
    	}

	// grades

    	public ArrayList getGradesForUser(int user_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList) this.execute("get_grades_for_user", params);
    	}

    	public ArrayList getGradesForClass(int class_id) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList) this.execute("get_grades_for_class", params);
    	}

    	public Map setGradesForAssignment(int assignment_id, Map[] grades) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("assignment_id", assignment_id);
        	JSONArray gradesJSON = new JSONArray(grades);
        	params.put("grades[]", gradesJSON);
        	return (Map) this.execute("set_grades_for_assignment", params);
    	}

 	// mastery

    	public ArrayList getMasteryForClass(int class_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList) this.execute("get_mastery_for_class", params);
    	}

	// attendance

    	public ArrayList getAllAttendance(int class_id) throws ApiException {
       		Map<String,Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList) this.execute("get_all_attendance", params);
    	}

    	public ArrayList getAttendance(int class_id, Date date_and_time) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("date_and_time", date_and_time);
        	return (ArrayList) this.execute("get_attendance", params);
    	}

	// news feeds

    	public int postClassAnnouncement(int class_id, String message, Map<String, Object> options) throws ApiException {
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("message", message);
        	params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_class_announcement", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

   	public int postClassMessage(int class_id, String message, Map options) throws ApiException {
      		Map<String,Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params.put("message", message);
        	params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_class_message", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

    	public int postGroupAnnouncement(int group_id, String message, Map options) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	params.put("message", message);
        	params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_group_announcement", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

    	public int postGroupMessage(int group_id, String message, Map options) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("group_id", group_id);
        	params.put("message", message);
        	params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_group_message", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

    	public int postSiteAnnouncement(String message, Map options) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("message", message);
        	params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_site_announcement", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

    	public int postSiteMessage(String message, Map options) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("message", message);
       		params = mergeOptionsToParams(params, options);
        	Map response = (Map)this.execute("post_site_message", params);
        	return (Integer)ensureValueFromMap(response, "posted");
    	}

	// games

    	public ArrayList getGamesForSite() throws ApiException {
     		return (ArrayList)this.execute("get_games_for_site");
    	}
    
    	public ArrayList getGamesForClass(int class_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	return (ArrayList)this.execute("get_games_for_class", params);
    	}
  
    	public ArrayList getStatusForAllPlayers(int game_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("game_id", game_id);
        	return (ArrayList)this.execute("get_status_for_all_players", params);
    	}
     
    	public ArrayList getStatusForPlayers(int game_id, int[] user_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("game_id", game_id);
        	params.put("user_ids[]", user_ids);
        	return (ArrayList) this.execute("get_status_for_players", params);
    	}

	// sessions

    	public ArrayList getSessionDetails(int[] user_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("user_ids[]", user_ids);
        	return (ArrayList) this.execute("get_session_details", params);
    	}

	// reports

    	public ArrayList getClassReport(int class_id, Map<String, Object> conditions) throws ApiException{
        	Map<String, Object> params = new HashMap<String, Object>();
        	params.put("class_id", class_id);
        	params = mergeOptionsToParams(params, conditions);
        	return (ArrayList) this.execute("get_class_report", params);
    	}

      // e-commerce

    	public ArrayList getAllOrders() throws ApiException {
     		return (ArrayList)this.execute("get_all_orders");
    	}

  	public ArrayList getOrdersWithIds(int[] order_ids) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("order_ids[]", order_ids);
        	return (ArrayList) this.execute("get_orders_with_ids", params);
    	}

 	public ArrayList getOrdersForOrganization(int organization_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("organization_id", organization_id);
        	return (ArrayList)this.execute("get_orders_for_organization", params);
    	}

 	public ArrayList getOrdersForUser(int user_id) throws ApiException {
        	Map<String,Object> params = new HashMap<String, Object>();
        	params.put("user_id", user_id);
        	return (ArrayList)this.execute("get_orders_for_user", params);
    	}

  ////

    private Object execute(String path) throws ApiException{
        return this.execute(path, null);
    }

    private Object execute(String path, Map<String,Object> params) throws ApiException {
        Object response;

        GetRequest request = getRequest(path);
        if (params != null){
            for (Map.Entry<String, Object> entry : params.entrySet()){
                JSONArray paramsArray = null;

                if (entry.getValue()!=null && entry.getValue().getClass().isArray()){  
		  paramsArray = new JSONArray(entry.getValue());					
                }

                if(entry.getValue() instanceof JSONArray) {
                    paramsArray = (JSONArray) entry.getValue();
                }

                if (paramsArray != null){
                    for (int i = 0; i < paramsArray.length(); i++) {
			request.queryString(entry.getKey(), paramsArray.get(i));
                    }
                } else {
                    request.queryString(entry.getKey(), entry.getValue());
                }
            }
        }

        try {
            JsonNode node = request.asJson().getBody();
            response = readValue(node.isArray() ? node.getArray() : node.getObject());
        } catch (UnirestException e) {
            throw new ApiException(e);
        }
        return response;
    }

    public void shutdown() throws IOException {
        Unirest.shutdown();
    }

    private GetRequest getRequest(String path){
        String url = host + "/api/" + path ;
        GetRequest request = Unirest.get(url);
        request.queryString("api_key", api_key);
        return request;
    }

    private Map<String, Object> mergeOptionsToParams(Map<String, Object> params, Map<String, Object> conditions) {
        if (conditions != null){
            for (Map.Entry<String, Object> condition: conditions.entrySet()) {
                String key = condition.getKey();
                Object value = condition.getValue();
                if (value.getClass().isArray()){
                    key = key + "[]";
                }
                params.put(key, value);
            }
        }
        return params;
    }
    
    private Object readValue(Object inputObject){
        Object response = inputObject;
        if (inputObject instanceof JSONArray) {
            ArrayList arrayList = new ArrayList();
            JSONArray jsonArray = (JSONArray) inputObject;
            for (int i = 0; i < jsonArray.length(); i++) {
                arrayList.add(readValue(jsonArray.get(i)));
            }
            response = arrayList;
        } else if (inputObject instanceof JSONObject) {
            Map<String, Object> map = new HashMap<String, Object>();
            JSONObject jsonObject = (JSONObject) inputObject;
            Iterator iterator = jsonObject.keys();
            while (iterator.hasNext()) {
                String key = (String)iterator.next();
                Object value = jsonObject.get(key);
                if ((value instanceof JSONArray) || (value instanceof JSONObject)) {
                    value = readValue(value);
                }
                map.put(key, value);
            }
            response = map;
        }
        return response;
    }

    private Object ensureValueFromMap(Map map, String key) throws ApiException{
        Object response = map.get(key);
        if (response == null){
            String message = (String)map.get("message");
            throw new ApiException(message);
        }
        return response;
    }
}
