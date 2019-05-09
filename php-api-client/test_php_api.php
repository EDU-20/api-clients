<?php
require 'lms_api.php';

echo "<pre>";

$API_KEY = "YOUR_API_KEY";
$api_client = new Api(
	array(
		'host' => "sandbox.edu20.com",
		'api_key' => $API_KEY,
		'api_version' => 1,
		'use_ssl' => false
	)
);

echo "Api version: " . print_r($api_client->get_version(), true) ;
echo "Get my account: " . print_r($api_client->get_my_account(),true) ;	
echo "Get all users: " . print_r($api_client->get_all_users(),true) ;	

$users_ids = array(162919, 162920);
echo "Get users with ids: " . print_r($api_client->get_users_with_ids($users_ids),true) ;	
$user_match_params = array("userid" => "S1X");   
echo "Get users that match: " . print_r($api_client->get_users_that_match($user_match_params),true);
$user_params = array("first_name" => "John","last_name" => "Doe", "account_types" => "student");  
echo "Add user: " . print_r($api_client->add_user($user_params),true);
echo "Archive user:  " . print_r($api_client->archive_students(array(249433)),true);
echo "Reactivate user: " . print_r($api_client->reactivate_students(array(249433)),true);

echo "Get all classes: " . sizeof($api_client->get_all_classes()); #153
echo "Get classes with IDs: " . sizeof($api_client->get_classes_with_ids(array(18675))); #1
echo "Get classes for Organization:  " . sizeof($api_client->get_classes_for_organization(array(4404))); # 151
$course_match_params = array("name" => "bb1");   
echo "Get classes that match:  " . sizeof($api_client->get_classes_that_match($course_match_params)); #1
echo "Get classes taught by:  " . sizeof($api_client->get_classes_taught_by(array(324961))); #249433
echo "Get classes enrolled by:  " . sizeof($api_client->get_classes_enrolled_by(array(324961)));
echo "Get teachers for class:  " . sizeof($api_client->get_teachers_for_class(array(27919)));
echo "Get students for class:  " . sizeof($api_client->get_students_for_class(array(27919)));
echo "Add students to class:  " . print_r($api_client->add_students_to_class(18675, array(249380)),true); // new int[]{249380, 287224}
echo "Remove students from class:  " . print_r($api_client->remove_students_from_class(27919, array(249433)),true); #249433
echo "Get status of classes :  " . print_r($api_client->get_status_of_classes(array(249380)),true);
echo "Archive classes :  " . print_r($api_client->archive_classes(array(249380)),true);
echo "Reactivate classes :  " . print_r($api_client->reactivate_classes(array(249380)),true);
echo "Delete classes :  " . print_r($api_client->delete_classes(array(249380)),true);
echo "Restore classes :  " . print_r($api_client->restore_classes(array(249380)),true);

echo "Get All groups " . sizeof($api_client->get_all_groups());
echo "Get All groups with ids" . print_r($api_client->get_groups_with_ids(array(3486)),true);
$groups_match_params = array("name" => "Test");
echo "Get groups that match: " . sizeof($api_client->get_groups_that_match($groups_match_params));
echo "Get members for group: " . sizeof($api_client->get_members_for_group(array(3486)));
echo "Add members to group:  " . print_r($api_client->add_members_to_group(3486,array(162919)),true);
echo "Add admins to group:  " . print_r($api_client->add_admins_to_group(3486,array(162919)),true);

echo "getAdminsForGroup: " . print_r($api_client->get_admins_for_group(3486),true);
echo "getGroupsWithMember" . print_r($api_client->get_groups_with_member(162919),true);
echo "getGroupsWithAdmin" . print_r($api_client->get_groups_with_admin(162919),true);

$api_client->remove_admins_from_group(3486, array(162919));
$api_client->remove_members_from_group(3486, array(162919));
$group_params = array("name" => "TestAPIGroup");
echo "Add  group:  " . print_r($api_client->add_group($group_params),true);
$group_attributes = array("name"=> "Group1888");
echo "Edit group :  " . print_r($api_client->edit_group(8750, $group_attributes),true);
echo "Delete groups with ids:  " . print_r($api_client->delete_groups(array(9871)),true);
	
$resources_params = array('type' => 'File');
echo "getResources : " . print_r($api_client->get_resources($resources_params),true);

echo "getAllOrganizations: " . print_r($api_client->get_all_organizations(),true);
echo "getOrganizationsWithIDs: " . print_r($api_client->get_organizations_with_ids(array(4404, 8099)),true);
$organization_params = array("name" => "OrganizationAPI");
echo "Add  organization:  " . print_r($api_client->add_organization($organization_params),true);
$organization_attributes = array("name"=> "OrganizationAPI2");
echo "Edit organization :  " . print_r($api_client->edit_organization(8099, $organization_attributes),true);
echo "Delete organizations with ids:  " . print_r($api_client->delete_organizations(array(26517)),true);

echo "get_all_paths: " . print_r($api_client->get_all_paths(),true);
echo "get_paths_with_ids: " . print_r($api_client->get_paths_with_ids(array(457,458)),true);   
echo "get_admins_for_path: " . print_r($api_client->get_admins_for_path(458),true);
echo "get_students_for_path: " . print_r($api_client->get_students_for_path(458),true);
echo "add_students_to_path: " . print_r($api_client->add_students_to_path(458, array(249395,249396)),true);
echo "remove_students_from_path: " . print_r($api_client->remove_students_from_path(458, array(249395,249396)),true);

echo "getAllCertificates: " . print_r($api_client->get_all_certificates(),true);
echo "getCertificatesWithIDs: " . print_r($api_client->get_certificates_with_ids(array(1318)),true);

echo "getAllCurricula: " . print_r($api_client->get_all_curricula(),true);
echo "getCurriculaWithIDs: " . print_r($api_client->get_curricula_with_ids(array(915,3949)),true);
echo "getProficienciesForCurriculum: " . print_r($api_client->get_proficiencies_for_curriculum(915),true);

echo "getLessonsForClass: " . print_r($api_client->get_lessons_for_class(18675),true);
echo "getAssignmentsForClass: " . print_r($api_client->get_assignments_for_class(18675),true);

echo "getGradesForClass: " . print_r($api_client->get_grades_for_class(18675),true);
echo "getGradesForUser: " . print_r($api_client->get_grades_for_user(249380),true);
	
$grades = array(
	array("user_id" => 249380, "grade" => "A"),
	array("user_id" => 287224, "grade" => "B")	
);

echo "setGradesForAssignment: " . print_r($api_client->set_grades_for_assignment(79063, $grades));

echo "getAllAttendance: " . print_r($api_client->get_all_attendance(18675),true);
echo "getAttendance: " . print_r($api_client->get_attendance(18675, '2015-10-20') ,true);

echo "postClassAnnouncement: " . print_r($api_client->post_class_announcement(18675, "Class announcement", null),true);
echo "postClassMessage: " . print_r($api_client->post_class_message(18675, "Class message", null),true);
echo "postGroupAnnouncement: " . print_r($api_client->post_group_announcement(3486, "Group announcement", null),true);
echo "postGroupMessage: " . print_r($api_client->post_group_message(3486, "Group message", null),true);
echo "postSiteAnnouncement: " . print_r($api_client->post_site_announcement("Site announcement", null),true);
echo "postSiteMessage: " . print_r($api_client->post_site_message("Site Message", null),true);

echo "Get Games For Site: " . print_r($api_client->get_games_for_site(),true);
echo "Get Games For Class: " . print_r($api_client->get_games_for_class(38688),true);
echo "Get Status for all players: " . print_r($api_client->get_status_for_all_players(2326),true);
echo "Get Status for players: " . print_r($api_client->get_status_for_players(2326, array(249393,249394)),true);

echo "getSessionDetails: " . print_r($api_client->get_session_details(array(314432)),true);

$conditions = array("student_ids" => array(249380), "from" =>  '2015-10-16', "to" => '2015-10-20' );
echo "getClassReport: " . print_r($api_client->get_class_report(18675, $conditions),true);

echo "</pre>";
?>
