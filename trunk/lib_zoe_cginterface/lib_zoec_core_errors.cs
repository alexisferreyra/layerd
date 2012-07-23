/*******************************************************************************
* Copyright (c) 2008, 2012 Alexis Ferreyra, Intel Corporation.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*       Alexis Ferreyra - initial API and implementation
*       Alexis Ferreyra (Intel Corporation)
*******************************************************************************/
/****************************************************************************
 
  Base library for Zoe Output Modules
  
  Original Author: Alexis Ferreyra
  Contact: alexis.ferreyra@layerd.net
  
  Please visit http://layerd.net to get the last version
  of the software and information about LayerD technology.

****************************************************************************/
/*-
 * Copyright (c) 2008 Alexis Ferreyra
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. Neither the name of copyright holders nor the names of its
 *    contributors may be used to endorse or promote products derived
 *    from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL COPYRIGHT HOLDERS OR CONTRIBUTORS
 * BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

// Archivo: lib_layerdxplc_core_errors.cs 
//
// Declara clases e interfaces para el control de 
// errores y advertancias estándar del compilador 
// Zoe.
//

using System;
using System.Collections;
using LayerD.CodeDOM;

namespace LayerD.ZOECompiler
{
    /// <summary>
    /// In which component the error was raised
    /// </summary>
    public enum ErrorSource
    {
        /// <summary>
        /// Zoe compiler core
        /// </summary>
        Core,
        /// <summary>
        /// Zoe semantic analizer
        /// </summary>
        SemanticAnalizer,
        /// <summary>
        /// Zoe factory library
        /// </summary>
        FactoryLibrary,
        /// <summary>
        /// Zoe subprogram loader
        /// </summary>
        ProgramLoader,
        /// <summary>
        /// Zoe factory module generator
        /// </summary>
        ModuleGenerator,
        /// <summary>
        /// Zoe code splitter
        /// </summary>
        CodeSplitter,
        /// <summary>
        /// Zoe building controler (compile time controler)
        /// </summary>
        BuildingControler,
        /// <summary>
        /// Zoe output module
        /// </summary>
        OutputModule,
        /// <summary>
        /// High level layerd compiler
        /// </summary>
        LayerDCompiler,
        /// <summary>
        /// Other module
        /// </summary>
        Unspecified
    }
    /// <summary>
    /// Classes of errors.
    /// </summary>
    public enum ErrorClass
    {
        /// <summary>
        /// The erros is an irrecuperable compilation error 
        /// </summary>
        Error,
        /// <summary>
        /// The erros is a warning
        /// </summary>
        Warning,
        /// <summary>
        /// The erros is an advice
        /// </summary>
        Advice,
        /// <summary>
        /// The erros is a notification
        /// </summary>
        Notification
    }
    /// <summary>
    /// Error severity level. The maximum severity level is One, the minimum is Ten.
    /// </summary>
    public enum ErrorLevel
    {
        /// <summary>
        /// The maximum error level
        /// </summary>
        One = 10,
        /// <summary>
        /// High error level
        /// </summary>
        Two = 9,
        /// <summary>
        /// High error level
        /// </summary>
        Three = 8,
        /// <summary>
        /// High error level
        /// </summary>
        Four = 7,
        /// <summary>
        /// Normal error level
        /// </summary>
        Five = 6,
        /// <summary>
        /// Low error level
        /// </summary>
        Six = 5,
        /// <summary>
        /// Low error level
        /// </summary>
        Seven = 4,
        /// <summary>
        /// Low error level
        /// </summary>
        Eight = 3,
        /// <summary>
        /// Low error level
        /// </summary>
        Nine = 2,
        /// <summary>
        /// Minimum error level
        /// </summary>
        Ten = 1,
        /// <summary>
        /// The minimum level
        /// </summary>
        MinLevel = Ten,
        /// <summary>
        /// The maximum level
        /// </summary>
        MaxLevel = One
    }
    /// <summary>
    /// Types of error like lexical, sintactical, etc.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Lexical error
        /// </summary>
        LexicalError,
        /// <summary>
        /// Syntax error
        /// </summary>
        SyntaxError,
        /// <summary>
        /// Semantic error
        /// </summary>
        SemanticError,
        /// <summary>
        /// Error on code generation
        /// </summary>
        CodeGenerationError,
        /// <summary>
        /// Error on type declaration
        /// </summary>
        TypeDeclarationError,
        /// <summary>
        /// Custom error
        /// </summary>
        CustomError
    }
    /// <summary>
    /// Base interface for Zoe errors
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Get the error source.
        /// </summary>
        /// <returns>A ErrorSource value.</returns>
        ErrorSource get_ErrorSource();
        /// <summary>
        /// Set the error source.
        /// </summary>
        /// <param name="newErrorSource">The new error source.</param>
        void set_ErrorSource(ErrorSource newErrorSource);
        /// <summary>
        /// Get the type of the error.
        /// </summary>
        /// <returns></returns>
        ErrorType get_ErrorType();
        /// <summary>
        /// Set the type of the error.
        /// </summary>
        /// <param name="newErrorType">New type of the error.</param>
        void set_ErrorType(ErrorType newErrorType);
        /// <summary>
        /// Get the error message.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_ErrorMessage();
        /// <summary>
        /// Set the error message.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        void set_ErrorMessage(string newErrorMessage);
        /// <summary>
        /// Get the locale error message.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_LocaleErrorMessage();
        /// <summary>
        /// Set the locale error message.
        /// </summary>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        void set_LocaleErrorMessage(string newLocaleErrorMessage);
        /// <summary>
        /// Get the URL error description.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_UrlErrorDescription();
        /// <summary>
        /// Set the URL error description.
        /// </summary>
        /// <param name="newUrlErrorDescription">The new URL error description.</param>
        void set_UrlErrorDescription(string newUrlErrorDescription);
        /// <summary>
        /// Get the URL error help.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_UrlErrorHelp();
        /// <summary>
        /// Set the URL error help.
        /// </summary>
        /// <param name="newUrlErrorHelp">The new URL error help.</param>
        void set_UrlErrorHelp(string newUrlErrorHelp);
        /// <summary>
        /// Get the related error.
        /// </summary>
        /// <returns>A IError value.</returns>
        IError get_RelatedError();
        /// <summary>
        /// Set the related error.
        /// </summary>
        /// <param name="newRelatedError">The new related error.</param>
        void set_RelatedError(IError newRelatedError);
        /// <summary>
        /// Get the error source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_ErrorSourceFileData();
        /// <summary>
        /// Set the error source file data.
        /// </summary>
        /// <param name="newErrorSourceFileData">The new error source file data.</param>
        void set_ErrorSourceFileData(string newErrorSourceFileData);
        /// <summary>
        /// Get the error layer D source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_ErrorLayerDSourceFileData();
        /// <summary>
        /// Set the error layer D source file data.
        /// </summary>
        /// <param name="newErrorLayerDSourceFileData">The new error layer D source file data.</param>
        void set_ErrorLayerDSourceFileData(string newErrorLayerDSourceFileData);
        /// <summary>
        /// Get the error layer DZOE source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        string get_ErrorLayerDZOESourceFileData();
        /// <summary>
        /// Set the error layer DZOE source file data.
        /// </summary>
        /// <param name="newErrorLayerDZOESourceFileData">The new error layer DZOE source file data.</param>
        void set_ErrorLayerDZOESourceFileData(string newErrorLayerDZOESourceFileData);
        /// <summary>
        /// Get the error class.
        /// </summary>
        /// <returns>A ErrorClass value.</returns>
        ErrorClass get_ErrorClass();
        /// <summary>
        /// Set the error class.
        /// </summary>
        /// <param name="newErrorClass">The new error class.</param>
        void set_ErrorClass(ErrorClass newErrorClass);
        /// <summary>
        /// Get the error level.
        /// </summary>
        /// <returns>A ErrorLevel value.</returns>
        ErrorLevel get_ErrorLevel();
        /// <summary>
        /// Set the error level.
        /// </summary>
        /// <param name="newErrorLevel">The new error level.</param>
        void set_ErrorLevel(ErrorLevel newErrorLevel);
        /// <summary>
        /// Set the error node.
        /// </summary>
        /// <param name="errorNode">The error node.</param>
        void set_ErrorNode(XplNode errorNode);
        /// <summary>
        /// Get the error node.
        /// </summary>
        /// <returns>A XplNode value.</returns>
        XplNode get_ErrorNode();
        /// <summary>
        /// Set the persistent error.
        /// </summary>
        /// <param name="persistent">if set to <c>true</c> [persistent].</param>
        void set_PersistentError(bool persistent);
        /// <summary>
        /// Get the persistent error.
        /// </summary>
        /// <returns>A Boolean value.</returns>
        bool get_PersistentError();
        /// <summary>
        /// returns an string with the error code.
        /// </summary>
        /// <returns>error code string</returns>
        string get_ErrorCode();
        /// <summary>
        /// Set the error code identifier
        /// </summary>
        /// <param name="errorCode">error code string</param>
        void set_ErrorCode(string errorCode);
    }
    /// <summary>
    /// Interface that error collections must implement
    /// </summary>
    public interface IErrorCollection: IEnumerable
    {
        /// <summary>
        /// Get the total errors count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        int get_TotalErrorsCount();
        /// <summary>
        /// Get the errors count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        int get_ErrorsCount();
        /// <summary>
        /// Get the warnings count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        int get_WarningsCount();
        /// <summary>
        /// Get the advices count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        int get_AdvicesCount();
        /// <summary>
        /// Get the notifications count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        int get_NotificationsCount();
        /// <summary>
        /// Get the errors.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        IError[] get_Errors();
        /// <summary>
        /// Get the warnings.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        IError[] get_Warnings();
        /// <summary>
        /// Get the advices.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        IError[] get_Advices();
        /// <summary>
        /// Get the notifications.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        IError[] get_Notifications();
        /// <summary>
        /// Get the error.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>A IError value.</returns>
        IError get_Error(int index);
        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="newError">The new error.</param>
        void AddError(IError newError);
        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="index">The index.</param>
        void RemoveError(int index);
        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="oldError">The old error.</param>
        void RemoveError(IError oldError);
        /// <summary>
        /// Merges the specified i error collection.
        /// </summary>
        /// <param name="iErrorCollection">The i error collection.</param>
        void Merge(IErrorCollection iErrorCollection);
        /// <summary>
        /// Clears the error list.
        /// </summary>
        void Clear();
    }
    /// <summary>
    /// Implement a collection of errors
    /// </summary>
    public class ErrorCollection : ArrayList , IErrorCollection
    {
        #region IErrorCollection Members

        /// <summary>
        /// Get the total errors count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        public int get_TotalErrorsCount()
        {
            return this.Count;
        }

        /// <summary>
        /// Get the errors count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        public int get_ErrorsCount()
        {
            int retCount = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Error) retCount++;
            return retCount;
        }

        /// <summary>
        /// Get the warnings count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        public int get_WarningsCount()
        {
            int retCount = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Warning) retCount++;
            return retCount;
        }

        /// <summary>
        /// Get the advices count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        public int get_AdvicesCount()
        {
            int retCount = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Advice) retCount++;
            return retCount;
        }

        /// <summary>
        /// Get the notifications count.
        /// </summary>
        /// <returns>A Int32 value.</returns>
        public int get_NotificationsCount()
        {
            int retCount = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Notification) retCount++;
            return retCount;
        }

        /// <summary>
        /// Get the errors.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        public IError[] get_Errors()
        {
            IError[] errores = new IError[get_ErrorsCount()];
            int count = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Error)
                {
                    errores[count] = error;
                    count++;
                }
            return errores;
        }

        /// <summary>
        /// Get the warnings.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        public IError[] get_Warnings()
        {
            IError[] errores = new IError[get_WarningsCount()];
            int count = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Warning)
                {
                    errores[count] = error;
                    count++;
                }
            return errores;
        }

        /// <summary>
        /// Get the advices.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        public IError[] get_Advices()
        {
            IError[] errores = new IError[get_AdvicesCount()];
            int count = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Advice)
                {
                    errores[count] = error;
                    count++;
                }
            return errores;
        }

        /// <summary>
        /// Get the notifications.
        /// </summary>
        /// <returns>A IError[] value.</returns>
        public IError[] get_Notifications()
        {
            IError[] errores = new IError[get_NotificationsCount()];
            int count = 0;
            foreach (IError error in this)
                if (error.get_ErrorClass() == ErrorClass.Notification)
                {
                    errores[count] = error;
                    count++;
                }
            return errores;
        }

        /// <summary>
        /// Get the error.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>A IError value.</returns>
        public IError get_Error(int index)
        {
            return (IError)this[index];
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="newError">The new error.</param>
        public void AddError(IError newError)
        {
            this.Add(newError);
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveError(int index)
        {
            this.RemoveAt(index);
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="oldError">The old error.</param>
        public void RemoveError(IError oldError)
        {
            this.Remove(oldError);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <summary>
        /// Merges the specified ierrors.
        /// </summary>
        /// <param name="ierrors">The ierrors.</param>
        public void Merge(IErrorCollection ierrors)
        {
            if (ierrors == null) return;
            foreach (object err in ierrors)
                this.Add(err);
        }
        /// <summary>
        /// Quita todos los elementos de la clase <see cref="T:System.Collections.ArrayList"></see>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException"><see cref="T:System.Collections.ArrayList"></see> es de sólo lectura.O bien,<see cref="T:System.Collections.ArrayList"></see> tiene un tamaño fijo. </exception>
        public override void Clear()
        {
            base.Clear();
        }

        #endregion
    }

    /// <summary>
    /// Represent an error while Zoe compile time
    /// </summary>
    public class Error : IError
    {
        #region Datos Privados
        ErrorSource p_errorSource;
        ErrorType p_errorType;
        string p_errorMessage;
        string p_localeErrorMessage;
        string p_urlErrorDescription;
        string p_urlErrorHelp;
        IError p_relatedError;
        string p_errorSourceFileData;
        string p_errorLayerDSourceFileData;
        string p_errorLayerDZOESourceFileData;
        ErrorClass p_errorClass;
        ErrorLevel p_errorLevel;
        XplNode p_errorNode;
        bool p_persistentError;
        string p_errorCode = "N/A";
        #endregion

        #region Constructores
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="errorNode">The error node.</param>
        public Error(string newErrorMessage, XplNode errorNode)
        {
            p_errorMessage = p_localeErrorMessage = newErrorMessage;
            p_errorNode = errorNode;
            p_errorClass = ErrorClass.Error;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        public Error(string newErrorMessage)
        {
            p_errorMessage = p_localeErrorMessage = newErrorMessage;
            p_errorClass = ErrorClass.Error;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newErrorClass">The new error class.</param>
        public Error(string newErrorMessage, ErrorClass newErrorClass)
        {
            p_errorMessage = newErrorMessage;
            p_errorClass = newErrorClass;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        public Error(string newErrorMessage, string newLocaleErrorMessage)
        {
            p_errorMessage = newErrorMessage;
            p_localeErrorMessage = newLocaleErrorMessage;
            p_errorClass = ErrorClass.Error;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="errorNode">The error node.</param>
        public Error(string newErrorMessage, string newLocaleErrorMessage, XplNode errorNode)
        {
            p_errorMessage = newErrorMessage;
            p_errorNode = errorNode;
            p_localeErrorMessage = newLocaleErrorMessage;
            p_errorClass = ErrorClass.Error;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="newErrorClass">The new error class.</param>
        public Error(string newErrorMessage, string newLocaleErrorMessage, ErrorClass newErrorClass)
        {
            p_errorMessage = newErrorMessage;
            p_localeErrorMessage = newLocaleErrorMessage;
            p_errorClass = newErrorClass;
            p_errorLevel = ErrorLevel.MaxLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newErrorClass">The new error class.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Error(string newErrorMessage, ErrorClass newErrorClass, ErrorLevel newErrorLevel)
        {
            p_errorMessage = newErrorMessage;
            p_errorClass = newErrorClass;
            p_errorLevel = newErrorLevel;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="newErrorClass">The new error class.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Error(string newErrorMessage, string newLocaleErrorMessage, ErrorClass newErrorClass, ErrorLevel newErrorLevel)
        {
            p_errorMessage = newErrorMessage;
            p_localeErrorMessage = newLocaleErrorMessage;
            p_errorClass = newErrorClass;
            p_errorLevel = newErrorLevel;
        }
        #endregion

        #region IError Members
        /// <summary>
        /// Set the error node.
        /// </summary>
        /// <param name="errorNode">The error node.</param>
        public void set_ErrorNode(XplNode errorNode)
        {
            p_errorNode = errorNode;
        }
        /// <summary>
        /// Get the error node.
        /// </summary>
        /// <returns>A XplNode value.</returns>
        public XplNode get_ErrorNode()
        {
            return p_errorNode;
        }
        /// <summary>
        /// Get the error source.
        /// </summary>
        /// <returns>A ErrorSource value.</returns>
        public ErrorSource get_ErrorSource()
        {
            return p_errorSource;
        }

        /// <summary>
        /// Set the error source.
        /// </summary>
        /// <param name="newErrorSource">The new error source.</param>
        public void set_ErrorSource(ErrorSource newErrorSource)
        {
            p_errorSource = newErrorSource;
        }

        /// <summary>
        /// Get the type of the error.
        /// </summary>
        /// <returns></returns>
        public ErrorType get_ErrorType()
        {
            return p_errorType;
        }

        /// <summary>
        /// Set the type of the error.
        /// </summary>
        /// <param name="newErrorType">New type of the error.</param>
        public void set_ErrorType(ErrorType newErrorType)
        {
            p_errorType = newErrorType;
        }

        /// <summary>
        /// Get the error message.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_ErrorMessage()
        {
            return p_errorMessage;
        }

        /// <summary>
        /// Set the error message.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        public void set_ErrorMessage(string newErrorMessage)
        {
            p_errorMessage = newErrorMessage;
        }

        /// <summary>
        /// Get the locale error message.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_LocaleErrorMessage()
        {
            return p_localeErrorMessage;
        }

        /// <summary>
        /// Set the locale error message.
        /// </summary>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        public void set_LocaleErrorMessage(string newLocaleErrorMessage)
        {
            p_localeErrorMessage = newLocaleErrorMessage;
        }

        /// <summary>
        /// Get the URL error description.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_UrlErrorDescription()
        {
            return p_urlErrorDescription;
        }

        /// <summary>
        /// Set the URL error description.
        /// </summary>
        /// <param name="newUrlErrorDescription">The new URL error description.</param>
        public void set_UrlErrorDescription(string newUrlErrorDescription)
        {
            p_urlErrorDescription = newUrlErrorDescription;
        }

        /// <summary>
        /// Get the URL error help.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_UrlErrorHelp()
        {
            return p_urlErrorHelp;
        }

        /// <summary>
        /// Set the URL error help.
        /// </summary>
        /// <param name="newUrlErrorHelp">The new URL error help.</param>
        public void set_UrlErrorHelp(string newUrlErrorHelp)
        {
            p_urlErrorHelp = newUrlErrorHelp;
        }

        /// <summary>
        /// Get the related error.
        /// </summary>
        /// <returns>A IError value.</returns>
        public IError get_RelatedError()
        {
            return p_relatedError;
        }

        /// <summary>
        /// Set the related error.
        /// </summary>
        /// <param name="newRelatedError">The new related error.</param>
        public void set_RelatedError(IError newRelatedError)
        {
            p_relatedError = newRelatedError;
        }

        /// <summary>
        /// Get the error source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_ErrorSourceFileData()
        {
            return p_errorSourceFileData;
        }

        /// <summary>
        /// Set the error source file data.
        /// </summary>
        /// <param name="newErrorSourceFileData">The new error source file data.</param>
        public void set_ErrorSourceFileData(string newErrorSourceFileData)
        {
            p_errorSourceFileData = newErrorSourceFileData;
        }

        /// <summary>
        /// Get the layerd source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_ErrorLayerDSourceFileData()
        {
            if (p_errorNode == null)
                return p_errorLayerDSourceFileData;
            else
                return p_errorNode.FullSourceFileInfo;
        }

        /// <summary>
        /// Set the layerd source file data.
        /// </summary>
        /// <param name="newErrorLayerDSourceFileData">The new layerd source file data.</param>
        public void set_ErrorLayerDSourceFileData(string newErrorLayerDSourceFileData)
        {
            p_errorLayerDSourceFileData = newErrorLayerDSourceFileData;
        }

        /// <summary>
        /// Get the zoe source file data.
        /// </summary>
        /// <returns>A String value.</returns>
        public string get_ErrorLayerDZOESourceFileData()
        {
            return p_errorLayerDZOESourceFileData;
        }

        /// <summary>
        /// Set the zoe source file data.
        /// </summary>
        /// <param name="newErrorLayerDZOESourceFileData">The new zoe source file data.</param>
        public void set_ErrorLayerDZOESourceFileData(string newErrorLayerDZOESourceFileData)
        {
            p_errorLayerDZOESourceFileData = newErrorLayerDZOESourceFileData;
        }

        /// <summary>
        /// Get the error class.
        /// </summary>
        /// <returns>A ErrorClass value.</returns>
        public ErrorClass get_ErrorClass()
        {
            return p_errorClass;
        }

        /// <summary>
        /// Set the error class.
        /// </summary>
        /// <param name="newErrorClass">The new error class.</param>
        public void set_ErrorClass(ErrorClass newErrorClass)
        {
            p_errorClass = newErrorClass;
        }

        /// <summary>
        /// Get the error level.
        /// </summary>
        /// <returns>A ErrorLevel value.</returns>
        public ErrorLevel get_ErrorLevel()
        {
            return p_errorLevel;
        }

        /// <summary>
        /// Set the error level.
        /// </summary>
        /// <param name="newErrorLevel">The new error level.</param>
        public void set_ErrorLevel(ErrorLevel newErrorLevel)
        {
            p_errorLevel = newErrorLevel;
        }
        /// <summary>
        /// Set the persistent error.
        /// </summary>
        /// <param name="persistent">if set to <c>true</c> [persistent].</param>
        public void set_PersistentError(bool persistent)
        {
            p_persistentError = persistent;
        }
        /// <summary>
        /// Get the persistent error.
        /// </summary>
        /// <returns>A Boolean value.</returns>
        public bool get_PersistentError()
        {
            return p_persistentError;
        }

        public string get_ErrorCode()
        {
            return p_errorCode;
        }

        public void set_ErrorCode(string errorCode)
        {
            p_errorCode = errorCode;
        }
        #endregion

        /// <summary>
        /// String representation of the error.
        /// </summary>
        /// <returns>A string with the error.</returns>
        public override string ToString()
        {
            return p_errorMessage;
        }
    }

    #region Clases "Warning", "Advice" y "Notification"

    /// <summary>
    /// Derived error class that represent a warning. Warnings do not stop compilation.
    /// </summary>
    public class Warning : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        public Warning(string newErrorMessage)
            : base(newErrorMessage, ErrorClass.Warning)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="errorNode">The error node.</param>
        public Warning(string newErrorMessage, XplNode errorNode)
            : base(newErrorMessage, ErrorClass.Warning)
        {
            set_ErrorNode(errorNode);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Warning(string newErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, ErrorClass.Warning, newErrorLevel)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        public Warning(string newErrorMessage, string newLocaleErrorMessage)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Warning)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="errorNode">The error node.</param>
        public Warning(string newErrorMessage, string newLocaleErrorMessage, XplNode errorNode)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Warning)
        {
            set_ErrorNode(errorNode);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Warning"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Warning(string newErrorMessage, string newLocaleErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Warning, newErrorLevel)
        {
        }
    }
    /// <summary>
    /// Derived error class that represent Advices to programmers.
    /// Advices do not stop compilation.
    /// </summary>
    public class Advice : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Advice"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        public Advice(string newErrorMessage)
            : base(newErrorMessage, ErrorClass.Advice)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Advice"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Advice(string newErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, ErrorClass.Advice, newErrorLevel)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Advice"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        public Advice(string newErrorMessage, string newLocaleErrorMessage)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Advice)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Advice"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Advice(string newErrorMessage, string newLocaleErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Advice, newErrorLevel)
        {
        }
    }
    /// <summary>
    /// Derived error class that represent Notifications.
    /// Notificatios do not stop compilation.
    /// </summary>
    public class Notification : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        public Notification(string newErrorMessage)
            : base(newErrorMessage, ErrorClass.Notification)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Notification(string newErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, ErrorClass.Notification, newErrorLevel)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        public Notification(string newErrorMessage, string newLocaleErrorMessage)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Notification)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="newErrorMessage">The new error message.</param>
        /// <param name="newLocaleErrorMessage">The new locale error message.</param>
        /// <param name="newErrorLevel">The new error level.</param>
        public Notification(string newErrorMessage, string newLocaleErrorMessage, ErrorLevel newErrorLevel)
            : base(newErrorMessage, newLocaleErrorMessage, ErrorClass.Notification, newErrorLevel)
        {
        }
    }
    #endregion

}