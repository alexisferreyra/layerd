/*******************************************************************************
 * Copyright (c) 2012 Intel Corporation.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Alexis Ferreyra (Intel Corporation) - initial API and implementation and/or initial documentation
 *******************************************************************************/
using System;
namespace LayerD.OutputModules
{
	public static class ObjectiveCFlags
	{
	 	public const string StaticPC = "static";
        public const string TAG_CONTEXT_CHANGES_PREFIX = "%OBJC_ORIGINAL_CONTEXT[";
        public const string ANONYMOUS_DECL = "__apt_anonymous_decl__";
        public const string OBJC_GLOBAL_CLASS_TAG = "^this is a global class^";
        public const string OBJC_PROTOCOL_TAG = "%OBJC_PROTOCOL_DECL%";
        public const string GLOBAL_CLASS_NAME_PREFIX = "c_global";
	}
}

