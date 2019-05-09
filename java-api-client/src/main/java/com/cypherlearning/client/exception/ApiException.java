package com.cypherlearning.client.exception;


public class ApiException extends Exception {

    public ApiException(Exception e) {
        super(e);
    }

    public ApiException(String msg) {
        super(msg);
    }
};