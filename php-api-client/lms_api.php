<?php 
 # This is an open source PHP client for our API.
 # Feel free to modify it and share it freely.
 
 error_reporting(E_ALL);
 
Class Api {
	# host
	
	private $host;

	public function set_host($host) {
    $this->host = $host;
	}

	public function get_host() {
    return $this->host;
	}
	
	# api key

	private $api_key;

	public function set_api_key($api_key) {
    $this->api_key = $api_key;
	}

	public function get_api_key() {
    return $this->api_key;
	}
	
	# api version

	private $api_version;

	public function set_api_version($api_version) {
    $this->api_version = $api_version;
	}

	public function get_api_version() {
    return $this->api_version;
	}
	
	# use ssl

	private $use_ssl;

	public function set_use_ssl($use_ssl) {
    $this->use_ssl = $use_ssl;
	}

	public function get_use_ssl() {
    return $this->use_ssl;
	}
	
	# debug

	private $debug;

	public function set_debug($debug) {
    $this->debug = $debug;
	}

	public function get_debug() {
    return $this->debug;
	}
	
	# port

	private $port;

	public function set_port($port) {
    $this->port = $port;
	}

	public function get_port() {
    return $this->port;
	}

	# initialization
	
	public function __construct($attributes) {
    $this->host = $attributes['host'];
    $this->api_key = $attributes['api_key'];
		$this->api_version = $attributes['api_version'];
		$this->use_ssl = $attributes['use_ssl'];
		$this->debug = isset($attributes['debug']) ? $attributes['debug'] : false;
	
		if (isset($attributes['port'])) {
			$this->port = $attributes['port'];
		} else {
			$this->port = $this->use_ssl ? 443 : 80;
		}
	}
 
	# version
 
	public function get_version() {
    return $this->get('get_version');
	}

  # authentication

  public function is_authenticated($userid, $password) {
      return $this->get('is_authenticated', $userid, $password);
  }

	# accounts
 
 	public function get_my_account() {
    return $this->get('get_my_account');
	}
	
	# users
 
	public function get_all_users($page) {
    return $this->get('get_all_users', array('page' => $page));
	}

	public function get_users_with_ids($user_ids) {  
		return $this->get('get_users_with_ids', array('user_ids' => $this->to_array($user_ids)));
	}
  
	public function get_users_that_match($constraints, $page) {   
		return $this->get('get_users_that_match', array_merge($constraints, array('page' => $page)));
	}
  
  public function add_user($attributes){
    return $this->get('add_user', $attributes);
  }

	public function archive_students($user_ids) {
	  return $this->get('archive_students', array('user_ids' => $this->to_array($user_ids)));
	}

	public function reactivate_students($user_ids) {
  	return $this->get('reactivate_students', array('user_ids' => $this->to_array($user_ids)));
  }

  # classes
  
  public function get_all_classes($page) {
    return $this->get('get_all_classes', array('page' => $page));
  }
  
  public function get_classes_with_ids($class_ids) {
    return $this->get('get_classes_with_ids', array('class_ids' => $this->to_array($class_ids)));
  }
  
  public function get_classes_that_match($constraints, $page) {
    return $this->get('get_classes_that_match', array_merge($constraints, array('page' => $page)));
  }
  
  public function get_classes_for_organization($organization_id, $page) {
    return $this->get('get_classes_for_organization', array('organization_id' => $organization_id, 'page' => $page));
  }
  
  public function add_class($attributes) {
    return $this->get('add_class', $attributes);
  }

  public function add_class_from_template($class_template_id, $attributes) {
    return $this->get('add_class_from_template', array_merge($attributes, array('class_template_id' => $class_template_id)));
  }

  public function add_child_class($parent_class_id, $attributes) {
    return $this->get('add_child_class', array_merge($attributes, array('parent_class_id' => $parent_class_id)));
  }
      
  public function edit_class($class_id, $attributes) {
    return $this->get('edit_class', array_merge($attributes, array('class_id' => $class_id)));
  }

  public function archive_classes($class_ids) {
    return $this->get('archive_classes', array('class_ids' => $this->to_array($class_ids)));
  }

  public function reactivate_classes($class_ids) {
    return $this->get('reactivate_classes', array('class_ids' => $this->to_array($class_ids)));
  }

  public function delete_classes($class_ids) {
    return $this->get('delete_classes', array('class_ids' => $this->to_array($class_ids)));
  }

  public function restore_classes($class_ids) {
    return $this->get('restore_classes', array('class_ids' => $this->to_array($class_ids)));
  }

  # class templates

  public function get_all_class_templates($page) {
    return $this->get('get_all_class_templates', array('page' => $page));
  }
  
  public function get_class_templates_with_ids($class_ids) {
    return $this->get('get_class_templates_with_ids', array('class_ids' => $this->to_array($class_ids)));
  }
  
  public function get_class_templates_that_match($constraints, $page) {
    return $this->get('get_class_templates_that_match', array_merge($constraints, array('page' => $page)));
  }
  
  public function get_class_templates_for_organization($organization_id, $page) {
    return $this->get('get_class_templates_for_organization', array('organization_id' => $organization_id, 'page' => $page));
  }

  public function add_class_template($attributes) {
    return $this->get('add_class_template', $attributes);
  }

  public function edit_class_template($class_id, $attributes) {
    return $this->get('edit_class_template', array_merge($attributes, array('class_id' => $class_id)));
  }

  public function delete_class_templates($class_ids) {
    return $this->get('delete_class_templates', array('class_ids' => $this->to_array($class_ids)));
  }

  public function restore_class_templates($class_ids) {
    return $this->get('restore_class_templates', array('class_ids' => $this->to_array($class_ids)));
  }

  # teachers
  
  public function get_teachers_for_class($class_id) {
    return $this->get('get_teachers_for_class', array('class_id' => $class_id));
  }
  
  public function add_teachers_to_class($class_id, $user_ids) {
    return $this->get('add_teachers_to_class', array('class_id' => $class_id, 'user_ids' => $user_ids));    
	}
  
  public function remove_teachers_from_class($class_id, $user_ids) {
    return $this->get('remove_teachers_from_class', array('class_id' => $class_id, 'user_ids' => $user_ids));
	}
	  
  public function get_classes_taught_by($user_id) {
    return $this->get('get_classes_taught_by', array('user_id' => $user_id));
  }
  
  # students
  
  public function get_students_for_class($class_id) {
    return $this->get('get_students_for_class', array('class_id' => $class_id));
	}
  
  public function add_students_to_class($class_id, $user_ids) {
    return $this->get('add_students_to_class', array('class_id' => $class_id, 'user_ids' => $user_ids));    
	}
  
  public function remove_students_from_class($class_id, $user_ids) {
    return $this->get('remove_students_from_class', array('class_id' => $class_id, 'user_ids' => $user_ids));
	}

  public function deactivate_students_in_class($class_id, $user_ids) {
    return $this->get('deactivate_students_in_class', array('class_id' => $class_id, 'user_ids' => $user_ids));
	}

  public function reactivate_students_in_class($class_id, $user_ids) {
    return $this->get('reactivate_students_in_class', array('class_id' => $class_id, 'user_ids' => $user_ids));
	}

  public function get_status_of_classes($user_id){
    return $this->get('get_status_of_classes', array('user_id' => $user_id));
  }

  public function get_classes_enrolled_by($user_id) {
    return $this->get('get_classes_enrolled_by', array('user_id' => $user_id));
  }
  
  # groups

  public function get_all_groups($page) {
    return $this->get('get_all_groups', array('page' => $page));
  }

  public function get_groups_with_ids($group_ids){
    return $this->get('get_groups_with_ids', array('group_ids' => $this->to_array($group_ids)));
  }

  public function get_groups_that_match($constraints, $page) {
    return $this->get('get_groups_that_match', array_merge($constraints, array('page' => $page)));
  }

 public function add_group($attributes){
    return $this->get('add_group', $attributes);
  }

  public function edit_group($group_id, $attributes){
    return $this->get('edit_group', array_merge($attributes, array('group_id' => $group_id)));
  }

  public function delete_groups($group_ids){
     return $this->get('delete_groups', array('group_ids' => $group_ids));
  }
  
  # group members
 
  public function get_members_for_group($group_id) {
    return $this->get('get_members_for_group', array('group_id' => $group_id));
  }

  public function add_members_to_group($group_id, $user_ids) {
    return $this->get('add_members_to_group', array('group_id' => $group_id, 'user_ids' => $this->to_array($user_ids)));
  }

  public function remove_members_from_group($group_id, $user_ids) {
    return $this->get('remove_members_from_group', array('group_id' => $group_id, 'user_ids' => $this->to_array($user_ids)));
 	}

  public function get_groups_with_member($user_id) {
    return $this->get('get_groups_with_member', array ('user_id' => $user_id));
  }
  
  # group admins
  
  public function get_admins_for_group($group_id) {
    return $this->get('get_admins_for_group', array('group_id' => $group_id));
  }

  public function add_admins_to_group($group_id, $user_ids) {
    return $this->get('add_admins_to_group', array('group_id' => $group_id, 'user_ids' => $this->to_array($user_ids)));
  }

  public function remove_admins_from_group($group_id, $user_ids) {
    return $this->get('remove_admins_from_group', array('group_id' => $group_id, 'user_ids' => $this->to_array($user_ids)));
 	}

  public function get_groups_with_admin($user_id) {
    return $this->get('get_groups_with_admin', array('user_id' => $user_id));
  }

  # resources

  public function get_resources($constraints, $page){
    return $this->get('get_resources', array_merge($constraints, array('page' => $page)));
  }

  # organizations
  
  public function get_all_organizations($page) {
    return $this->get('get_all_organizations', array('page' => $page));
  }
  
  public function get_organizations_with_ids($organization_ids) {
    return $this->get('get_organizations_with_ids', array('organization_ids' => $this->to_array($organization_ids)));
  }

  public function add_organization($attributes){
    return $this->get('edit_organization', $attributes);
  }

  public function edit_organization($organization_id, $attributes){
    return $this->get('edit_organization', array_merge($attributes, array('organization_id' => $organization_id)));
  }

  public function delete_organizations($organization_ids){
     return $this->get('delete_organizations', array('organization_ids' => $this->to_array($organization_ids)));
  }

  # paths

	public function get_all_paths($page) {
    return $this->get('get_all_paths', array('page' => $page));
  }

	public function get_paths_with_ids($path_ids) {
    return $this->get('get_paths_with_ids', array('path_ids' =>  $this->to_array($path_ids)));
  }

  public function get_admins_for_path($path_id) {
    return $this->get('get_admins_for_path', array('path_id' => $path_id));
  }

  public function get_students_for_path($path_id) {
    return $this->get('get_students_for_path', array('path_id' => $path_id));
  }

  public function add_students_to_path($path_id, $user_ids) {
    return $this->get('add_students_to_path', array('path_id' => $path_id, 'user_ids' => $user_ids));
	}

  public function remove_students_from_path($path_id, $user_ids) {
    return $this->get('remove_students_from_path', array('path_id' => $path_id, 'user_ids' => $user_ids));
	}

  # certificates
  
	public function get_all_certificates() {
    return $this->get('get_all_certificates');
  }  
 
	public function get_certificates_with_ids($certificate_ids) {
    return $this->get('get_certificates_with_ids', array('certificate_ids' => $this->to_array($certificate_ids)));
  }

  # curricula

  public function get_all_curricula() {
    return $this->get('get_all_curricula');
  }

  public function get_curricula_with_ids($curriculum_ids) {
    return $this->get('get_curricula_with_ids', array('curriculum_ids' => $this->to_array($curriculum_ids)));
  }

  public function get_proficiencies_for_curriculum($curriculum_id) {
    return $this->get('get_proficiencies_for_curriculum', array('curriculum_id' => $curriculum_id));
  }

  # lessons
  
  public function get_lessons_for_class($class_id) {
    return $this->get('get_lessons_for_class', array('class_id' => $class_id));
  }

  # assignments
  
  public function get_assignments_for_class($class_id) {
    return $this->get('get_assignments_for_class', array('class_id' => $class_id));
  }

  # grades

  public function get_grades_for_class($class_id) {
    return $this->get('get_grades_for_class', array('class_id' => $class_id));
  }

  public function get_grades_for_user($user_id) {
    return $this->get('get_grades_for_user', array('user_id' => $user_id));
  }

  public function set_grades_for_assignment($assignment_id, $grades){
    $args = array();

    foreach ($grades as $grade) { # TO DO
      array_push($args, json_encode(array( 'user_id' => $grade['user_id'], 'grade' => urlencode($grade['grade']))));
    }
    return $this->get('set_grades_for_assignment', array_merge(array('assignment_id' => $assignment_id), array('grades' => $args)));
  }

  # mastery

  public function get_mastery_for_class($class_id) {
    return $this->get('get_mastery_for_class', array('class_id' => $class_id));
  }  

  # attendance

  public function get_all_attendance($class_id) {
    return $this->get('get_all_attendance', array('class_id' => $class_id));
  }

  public function get_attendance($class_id, $date_and_time) {
    return $this->get('get_attendance', array('class_id' => $class_id, 'date_and_time' => $date_and_time));
  }

  # news feeds   # TO DO

	public function post_class_announcement($class_id, $message, $options = array()) {
    return $this->get('post_class_announcement', array('class_id' => $class_id, 'message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null, 'notify' =>  isset($options['notify']) ? $options['notify'] : null, 'sticky' =>  isset($options['sticky']) ? $options['sticky'] : null));
  }

  public function post_class_message($class_id, $message, $options = array()) {
    return $this->get('post_class_message', array('class_id' => $class_id, 'message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null, 'sticky' =>  isset($options['sticky']) ? $options['sticky'] : null));
  }

	public function post_group_announcement($group_id, $message,  $options = array()) {
    return $this->get('post_group_announcement', array('group_id' => $group_id, 'message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null, 'notify' =>  isset($options['notify']) ? $options['notify'] : null, 'sticky' =>  isset($options['sticky']) ? $options['sticky'] : null));
  }

	public function post_group_message($group_id, $message, $options = array()) {
    return $this->get('post_group_message', array('group_id' => $group_id, 'message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null, 'sticky' =>  isset($options['sticky']) ? $options['sticky'] : null));
  }

	public function post_site_announcement($message, $options = array()) {
	  $students =  isset($options['students']) ? $options['students'] : null ;
	  $teachers =  isset($options['teachers']) ? $options['teachers'] : null ;
	  $managers =  isset($options['managers']) ? $options['managers'] : null ;
	  $parents =  isset($options['parents']) ? $options['parents'] : null ;
    return $this->get('post_site_announcement', array('message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null, 'notify' =>  isset($options['notify']) ? $options['notify'] : null, 'sticky' =>  isset($options['sticky']) ? $options['sticky'] : null,'students' => $students , 'teachers' => $teachers, 'managers' => $managers, 'parents' => $parents ));
  }

	public function post_site_message($message, $options = array()) {
    return $this->get('post_site_message', array('message' => $message, 'submitter_id' =>  isset($options['submitter_id']) ? $options['submitter_id'] : null));
  }

  # games
  
  public function get_games_for_site() {
    return $this->get('get_games_for_site');
  }

  public function get_games_for_class($class_id) {
    return $this->get('get_games_for_class', array('class_id' => $class_id));
  }
  
  public function get_status_for_all_players($game_id) {
    return $this->get('get_status_for_all_players', array('game_id' => $game_id));
  }
  
  public function get_status_for_players($game_id, $user_ids) {
    return $this->get('get_status_for_players', array('game_id' => $game_id, 'user_ids' => $this->to_array($user_ids)));
  }

  # sessions

	public function get_session_details($user_ids) {
    return $this->get('get_session_details', array('user_ids' =>  $this->to_array($user_ids)));
  }

  # reports

	public function get_class_report($class_id, $constraints) {
    return $this->get('get_class_report', array_merge(array('class_id' => $class_id), $constraints));
  }

  # e-commerce
  
  public function get_all_orders() {
    return $this->get('get_all_orders');
  }
  
 	public function get_orders_with_ids($order_ids) {
     return $this->get('get_orders_with_ids', array('order_ids' =>  $this->to_array($order_ids)));
  }
 
  public function get_orders_for_organization($organization_id) {
    return $this->get('get_orders_for_organization', array('organization_id' => $organization_id));
  }
 
  public function get_orders_for_user($user_id) {
    return $this->get('get_orders_for_user', array('user_id' => $user_id));
  }
          
	# invoke method via GET
 
	private function get($method, $args=array()) {
    if (strlen($this->api_key)) {
			$args['api_key'] = $this->api_key;
    }
    
    if (strlen($this->api_version)) {
			$args['api_version'] = $this->api_version;
    }
    
    $parts = array();
    
    foreach($args as $key=>$value) {
			if (is_array($value)) {
      	foreach($value as $part) {
					$parts[] = urlencode($key).'[]='.urlencode($part);
      	}
			}	else {
				$parts[] = urlencode($key).'='.urlencode($value);
			}
    }

    $path = ($this->use_ssl ? 'https://' : 'http://').$this->host.'/api/' . $method . '?' . implode('&', $parts);
    $result = file_get_contents($path);
    return json_decode($result);
	}
 
  public function to_array($ids) {
    if (is_array($ids)) {
    	return $ids;
    } else {
    	return explode(',', $ids);
    }
  } 
}