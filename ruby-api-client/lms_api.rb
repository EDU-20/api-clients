#-- encoding: UTF-8
require 'uri'
require 'net/http'
require 'net/https'
require 'json'

# This is an open source Ruby client for our API.
# Feel free to modify it and share it freely.

module LMS

  class Api
    attr_accessor :host, :port, :api_key, :api_version, :use_ssl, :debug, :timeout

    # initialization

    def initialize(attributes={})
      @host = attributes[:host]
      @api_key = attributes[:api_key]
      @api_version = attributes[:api_version]
      @use_ssl = (attributes[:use_ssl] == true)
      @debug = (attributes[:debug] == true)
      @port = (attributes[:port] || (use_ssl ? 443 : 80))
      @timeout = attributes[:timeout] # seconds
    end

    # version

    def get_version
      get('get_version')['version']
    end

    # authentication

    def is_authenticated(userid, password)
      get('is_authenticated', :userid => userid, :password => password)['authenticated']
    end

    # accounts

    def get_my_account
      get('get_my_account')
    end

    # users

    def get_all_users(page=nil)
      get('get_all_users', :page => page)
    end

    def get_users_with_ids(user_ids)
      get('get_users_with_ids', :user_ids => to_array(user_ids))
    end

    def get_users_that_match(constraints, page=nil)
      get('get_users_that_match', constraints.merge(:page => page))
    end

    def add_user(attributes)
      get('add_user', attributes)
    end

    def update_user(attributes)
      get('update_user', attributes)
    end

    def archive_users(user_ids)
      get('archive_users', :user_ids => to_array(user_ids))
    end

    def archive_students(user_ids)
      get('archive_students', :user_ids => to_array(user_ids))
    end

    def reactivate_users(user_ids)
      get('reactivate_users', :user_ids => to_array(user_ids))
    end

    def reactivate_students(user_ids)
      get('reactivate_students', :user_ids => to_array(user_ids))
    end

    # classes

    def get_all_classes(archived=nil, page=nil)
      get('get_all_classes', :archived => archived, :page => page)
    end

    def get_classes_with_ids(class_ids)
      get('get_classes_with_ids', :class_ids => to_array(class_ids))
    end

    def get_classes_that_match(constraints, page=nil)
      get('get_classes_that_match', constraints.merge(:page => page))
    end

    def get_classes_for_organization(organization_id, archived=nil, page=nil)
      get('get_classes_for_organization', :organization_id => organization_id, :archived => archived, :page => page)
    end

    def add_class(attributes)
      get('add_class', attributes)
    end

    def add_class_from_template(class_template_id, attributes={})
      get('add_class_from_template', attributes.merge(:class_template_id => class_template_id))
    end

    def add_child_class(parent_class_id, attributes={})
      get('add_child_class', attributes.merge(:parent_class_id => parent_class_id))
    end

    def edit_class(class_id, attributes)
      get('edit_class', attributes.merge(:class_id => class_id))
    end

    def archive_classes(class_ids)
      get('archive_classes', :class_ids => to_array(class_ids))
    end

    def reactivate_classes(class_ids)
      get('reactivate_classes', :class_ids => to_array(class_ids))
    end

    def delete_classes(class_ids)
      get('delete_classes', :class_ids => to_array(class_ids))
    end

    def restore_classes(class_ids)
      get('restore_classes', :class_ids => to_array(class_ids))
    end

    # class templates

    def get_all_class_templates(page=nil)
      get('get_all_class_templates', :page => page)
    end

    def get_class_templates_with_ids(class_ids)
      get('get_class_templates_with_ids', :class_ids => to_array(class_ids))
    end

    def get_class_templates_that_match(constraints, page=nil)
      get('get_class_templates_that_match', constraints.merge(:page => page))
    end

    def get_class_templates_for_organization(organization_id, page=nil)
      get('get_class_templates_for_organization', :organization_id => organization_id, :page => page)
    end

    def add_class_template(attributes)
      get('add_class_template', attributes)
    end

    def edit_class_template(class_id, attributes)
      get('edit_class_template', attributes.merge(:class_id => class_id))
    end

    def delete_class_templates(class_ids)
      get('delete_class_templates', :class_ids => to_array(class_ids))
    end

    def restore_class_templates(class_ids)
      get('restore_class_templates', :class_ids => to_array(class_ids))
    end

    # teachers

    def get_teachers_for_class(class_id)
      get('get_teachers_for_class', :class_id => class_id)
    end

    def add_teachers_to_class(class_id, user_ids, options={})
      get('add_teachers_to_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def remove_teachers_from_class(class_id, user_ids)
      get('remove_teachers_from_class', {:class_id => class_id, :user_ids => to_array(user_ids)})
    end

    def get_classes_taught_by(user_id)
      get('get_classes_taught_by', :user_id => user_id)
    end

    # students

    def get_students_for_class(class_id)
      get('get_students_for_class', :class_id => class_id)
    end

    def add_students_to_class(class_id, user_ids, options={})
      get('add_students_to_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def remove_students_from_class(class_id, user_ids, options={})
      get('remove_students_from_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def deactivate_students_in_class(class_id, user_ids, options={})
      get('deactivate_students_in_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def reactivate_students_in_class(class_id, user_ids, options={})
      get('reactivate_students_in_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def complete_students_in_class(class_id, user_ids, options={})
      get('complete_students_in_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def uncomplete_students_in_class(class_id, user_ids, options={})
      get('uncomplete_students_in_class', {:class_id => class_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def get_status_of_classes(user_id)
      get('get_status_of_classes', {:user_id => user_id})
    end

    def get_classes_enrolled_by(user_id)
      get('get_classes_enrolled_by', :user_id => user_id)
    end

    # groups

    def get_all_groups(page=nil)
      get('get_all_groups', :page => page)
    end

    def get_groups_with_ids(group_ids)
      get('get_groups_with_ids', :group_ids => to_array(group_ids))
    end

    def get_groups_that_match(constraints, page=nil)
      get('get_groups_that_match', constraints.merge(:page => page))
    end

    def add_group(attributes)
      get('add_group', attributes)
    end

    def edit_group(group_id, attributes)
      get('edit_group', attributes.merge(:group_id => group_id))
    end

    def delete_groups(group_ids)
      get('delete_groups', :group_ids => group_ids)
    end

    # group members

    def get_members_for_group(group_id)
      get('get_members_for_group', :group_id => group_id)
    end

    def add_members_to_group(group_id, user_ids)
      get('add_members_to_group', :group_id => group_id, :user_ids => to_array(user_ids))
    end

    def remove_members_from_group(group_id, user_ids)
      get('remove_members_from_group', :group_id => group_id, :user_ids => to_array(user_ids))
    end

    def get_groups_with_member(user_id)
      get('get_groups_with_member', :user_id => user_id)
    end

    # group admins

    def get_admins_for_group(group_id)
      get('get_admins_for_group', :group_id => group_id)
    end

    def add_admins_to_group(group_id, user_ids)
      get('add_admins_to_group', :group_id => group_id, :user_ids => to_array(user_ids))
    end

    def remove_admins_from_group(group_id, user_ids)
      get('remove_admins_from_group', :group_id => group_id, :user_ids => to_array(user_ids))
    end

    def get_groups_with_admin(user_id)
      get('get_groups_with_admin', :user_id => user_id)
    end

    # resources

    def get_resources(constraints, page=nil)
      get('get_resources', constraints.merge(:page => page))
    end

    # organizations

    def get_all_organizations(page=nil)
      get('get_all_organizations', :page => page)
    end

    def get_organizations_with_ids(organization_ids)
      get('get_organizations_with_ids', :organization_ids => to_array(organization_ids))
    end

    def add_organization(attributes)
      get('add_organization', attributes)
    end

    def edit_organization(organization_id, attributes)
      get('edit_organization', attributes.merge(:organization_id => organization_id))
    end

    def delete_organizations(organization_ids)
      get('delete_organizations', :organization_ids => to_array(organization_ids))
    end

    # paths

    def get_all_paths(page=nil)
      get('get_all_paths', :page => page)
    end

    def get_paths_with_ids(path_ids)
      get('get_paths_with_ids', :path_ids => to_array(path_ids))
    end

    def get_admins_for_path(path_id)
      get('get_admins_for_path', :path_id => path_id)
    end

    def get_students_for_path(path_id)
      get('get_students_for_path', :path_id => path_id)
    end

    def add_students_to_path(path_id, user_ids, options={})
      get('add_students_to_path', {:path_id => path_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    def remove_students_from_path(path_id, user_ids, options={})
      get('remove_students_from_path', {:path_id => path_id, :user_ids => to_array(user_ids)}.merge(options))
    end

    # certificates

    def get_all_certificates
      get('get_all_certificates')
    end

    def get_certificates_with_ids(certificate_ids)
      get('get_certificates_with_ids', :certificate_ids => to_array(certificate_ids))
    end

    # curricula

    def get_all_curricula
      get('get_all_curricula')
    end

    def get_curricula_with_ids(curriculum_ids)
      get('get_curricula_with_ids', :curriculum_ids => curriculum_ids)
    end

    def get_proficiencies_for_curriculum(curriculum_id)
      get('get_proficiencies_for_curriculum', :curriculum_id => curriculum_id)
    end

    # lessons

    def get_lessons_for_class(class_id)
      get('get_lessons_for_class', :class_id => class_id)
    end

    # assignments

    def get_assignments_for_class(class_id)
      get('get_assignments_for_class', :class_id => class_id)
    end

    # grades

    def get_grades_for_class(class_id)
      get('get_grades_for_class', :class_id => class_id)
    end

    def get_grades_for_user(user_id)
      get('get_grades_for_user', :user_id => user_id)
    end

    def set_grades_for_assignment(assignment_id, grades)
      args = []

      for grade in grades
        args << {:user_id => grade[:user_id], :grade => CGI.escape(grade[:grade])}.to_json
      end

      get('set_grades_for_assignment', {:assignment_id => assignment_id}.merge(:grades => args))
    end

    # mastery

    def get_mastery_for_class(class_id)
      get('get_mastery_for_class', :class_id => class_id)
    end

    # attendance

    def get_all_attendance(class_id)
      get('get_all_attendance', :class_id => class_id)
    end

    def get_attendance(class_id, date_and_time)
      get('get_attendance', :class_id => class_id, :date_and_time => date_and_time)
    end

    # news feeds

    def post_class_announcement(class_id, message, options={})
      get('post_class_announcement', :class_id => class_id, :message => message, :submitter_id => options[:submitter_id], :notify => options[:notify], :sticky => options[:sticky])
    end

    def post_class_message(class_id, message, options={})
      get('post_class_message', :class_id => class_id, :message => message, :submitter_id => options[:submitter_id], :sticky => options[:sticky])
    end

    def post_group_announcement(group_id, message, options={})
      get('post_group_announcement', :group_id => group_id, :message => message, :submitter_id => options[:submitter_id], :notify => options[:notify], :sticky => options[:sticky])
    end

    def post_group_message(group_id, message, options={})
      get('post_group_message', :group_id => group_id, :message => message, :submitter_id => options[:submitter_id], :sticky => options[:sticky])
    end

    def post_site_announcement(message, options={})
      get('post_site_announcement', :message => message, :submitter_id => options[:submitter_id], :notify => options[:notify], :sticky => options[:sticky], :students => options[:students], :teachers => options[:teachers], :managers => options[:managers], :parents => options[:parents])
    end

    def post_site_message(message, options={})
      get('post_site_message', :message => message, :submitter_id => options[:submitter_id])
    end

    # games

    def get_games_for_site
      get('get_games_for_site')
    end

    def get_games_for_class(class_id)
      get('get_games_for_class', :class_id => class_id)
    end

    def get_status_for_all_players(game_id)
      get('get_status_for_all_players', :game_id => game_id)
    end

    def get_status_for_players(game_id, user_ids)
      get('get_status_for_players', :game_id => game_id, :user_ids => to_array(user_ids))
    end

    # sessions

    def get_session_details(user_ids)
      get('get_session_details', :user_ids => to_array(user_ids))
    end

    # reports

    def get_class_report(class_id, constraints={})
      get('get_class_report', {:class_id => class_id}.merge(constraints))
    end

    # e-commerce

    def get_all_orders
      get('get_all_orders')
    end

    def get_orders_with_ids(order_ids)
      get('get_orders_with_ids', :order_ids => to_array(order_ids))
    end

    def get_orders_for_organization(organization_id)
      get('get_orders_for_organization', :organization_id => organization_id)
    end

    def get_orders_for_user(user_id)
      get('get_orders_for_user', :user_id => user_id)
    end

    private

    # array helper

    def to_array(ids)
      (ids.instance_of?(Array) ? ids : [ids])
    end

    # invoke method via GET

    def get(method, args={})
      http = new_http

      if api_key
        args[:api_key] = api_key
      end

      if api_version
        args[:api_version] = api_version
      end

      parts = []

      args.each do |key, value|
        if value.instance_of?(Array)
          for part in value
            # what if the part is a structure such as a hash?
            parts << "#{URI.escape(key.to_s)}[]=#{URI.escape(part.to_s)}"
          end
        elsif value
          parts << "#{URI.escape(key.to_s)}=#{URI.escape(value.to_s)}"
        end
      end

      path = '/api/' + method + '?' + parts.join('&')
      request = Net::HTTP::Get.new(path)
      result = invoke(http, request)
      JSON.parse(result.body)
    end

    # invoke method via POST

    def post(method, args=nil)
      http = new_http

      if api_key
        args[:api_key] = api_key
      end

      if api_version
        args[:api_version] = api_version
      end

      request = Net::HTTP::Post.new('/api/' + method)

      if args
        request.set_form_data(args)
      end

      result = invoke(http, request)
      JSON.parse(result.body)
    end

    # invoke

    def invoke(http, request)
      if debug
        puts "send #{http.inspect}, #{request.inspect}"
      end

      # add timeout support here
      result = http.start {|http| http.request(request)}

      if debug
        puts "received #{http.inspect}, #{result.body.inspect}"
      end

      case result
        when Net::HTTPSuccess
          result

        else
          begin
            json = JSON.parse(result.body)
          rescue
            result.error!
          end

          raise json['message']
      end
    end

    # http

    def new_http
      http = Net::HTTP.new(host, port)

      if timeout
        http.open_timeout = timeout
        http.read_timeout = timeout
      end

      http.use_ssl = use_ssl
      http
    end
  end

end