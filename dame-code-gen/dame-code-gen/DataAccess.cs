using System;

// TODO: Remove Try/Catches
// TODO: UpdateSingletonField
// TODO: Check all method.Replace's
// TODO: Add commas where needed

namespace damecodegen
{
    public static class DataAccess
    {
        //  (ie. getNotebookLuids)
        public static string GetAllOfField(string fieldName, string methodName, string returnName, string returnObjectField, string returnType, string tableName)
        {
            string method =
                "public List<{returnType}> {methodName}()\n" +
                "{\n" +
                "    List<{returnType}> {returnName} = new List<{returnType}>();\n" +
                "    PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"SELECT \" + Fields.{tableName}.{fieldName} + \" FROM \" + Tables.{tableName};\n" +
                "\n" +
                "        using (SQLDataReader reader = command.ExecuteReader())\n" +
                "        {\n" +
                "            while (reader.Read())\n" +
                "            {\n" +
                "                {returnName}.Add(reader.TryGetValue<{returnType}>(Fields.{tableName}.{returnObjectField}));\n" +
                "            }\n" +
                "            reader.Close();\n" +
                "        }\n" +
                "    });\n" +
                "    return {returnName};\n" +
                "}";

            method = method.Replace(FIELD_NAME, fieldName);
            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(RETURN_NAME, returnName);
            method = method.Replace(RETURN_OBJECT_FIELD, returnObjectField);
            method = method.Replace(RETURN_TYPE, returnType);
            method = method.Replace(TABLE_NAME, tableName);

            return method;
        }

        // (ie. getLastUpdateCount)
        public static string GetSingletonField(string returnType, string methodName, string returnName, string defaultValue, string fieldName, string returnObjectField, string tableName, string castType)
        {
            string method =
                "public {returnType} {methodName}()\n" +
                "{\n" +
                "    {returnType} {returnName} = {defaultValue};\n" +
                "    PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"SELECT \" + Fields.{tableName}.{fieldName} + \" FROM \" + Tables.{tableName};\n" +
                "\n" +
                "        using (SQLDataReader reader = command.ExecuteReader())\n" +
                "        {\n" +
                "            if (reader.Read())\n" +
                "            {\n" +
                "                {returnName} = ({returnType})reader.TryGetValue<{castType}>(Fields.{tableName}.{returnObjectField});\n" +
                "            }\n" +
                "            reader.Close();\n" +
                "        }\n" +
                "    });\n" +
                "    return {returnName};\n" +
                "}";

            method = method.Replace(RETURN_TYPE, returnType);
            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(RETURN_NAME, returnName);
            method = method.Replace(DEFAULT_VALUE, defaultValue);
            method = method.Replace(FIELD_NAME, fieldName);
            method = method.Replace(RETURN_OBJECT_FIELD, returnObjectField);
            method = method.Replace(TABLE_NAME, tableName);
            method = method.Replace(CAST_TYPE, castType);

            return method;
        }

        // DeleteObject
        public static string DeleteObject(string fieldName, string methodName, string parameterName, string parameterType, string tableName)
        {
            string method =
                "public void {methodName}({parameterType} {parameterName})\n" +
                "{\n" +
                "    PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"DELETE FROM \" + Tables.{tableName} + \" WHERE \" + Fields.{tableName}.{fieldName} + \"=\" + FieldParams.{tableName}.{fieldName};\n" +
                "\n" +
                "\n" +
                "        command.Parameters.AddWithValue(FieldParams.{tableName}.{fieldName}, {parameterName});\n" +
                "\n" +
                "        command.ExecuteNonQuery();\n" +
                "    });\n" +
                "}";

            method = method.Replace(FIELD_NAME, fieldName);
            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(PARAMETER_NAME, parameterName);
            method = method.Replace(PARAMETER_TYPE, parameterType);
            method = method.Replace(TABLE_NAME, tableName);

            return method;
        }

        public class GetObjectField
        {
            public string returnObjectFieldName;
            public string returnObjectFieldType;
            public string returnObjectField;
            public GetObjectField(string returnObjectFieldName, string returnObjectFieldType, string returnObjectField)
            {
                this.returnObjectFieldName = returnObjectFieldName;
                this.returnObjectFieldType = returnObjectFieldType;
                this.returnObjectField = returnObjectField;
            }
        }

        public class GetObjectSubtype
        {
            public string parentFieldName;
            public string gettermethodName;
            public GetObjectSubtype(string parentFieldName, string gettermethodName)
            {
                this.parentFieldName = parentFieldName;
                this.gettermethodName = gettermethodName;
            }
        }

        // (ie. getUser)
        public static string GetObject(string returnType, string methodName, string parameterType, string parameterName, string returnName, string defaultValue, string tableName, string fieldName, GetObjectField[] fields, GetObjectSubtype[] subtypes)
        {
            string method =
                "public {returnType} {methodName}({parameterType} {parameterName})\n" +
                "{\n" +
                "    {returnType} {returnName} = {defaultValue};\n" +
                "    PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"SELECT * FROM \" + Tables.{tableName} + \" WHERE \" + Fields.{tableName}.{fieldName} + \"=\" + FieldParams.{tableName}.{fieldName};\n" +
                "        command.Parameters.AddWithValue(FieldParams.{tableName}.{fieldName}, {parameterName});\n" +
                "\n" +
                "        using (SQLDataReader reader = command.ExecuteReader())\n" +
                "        {\n" +
                "            if (reader.Read())\n" +
                "            {\n" +
                "                var temp = new {returnType}();\n";

            // Add All Fields
            foreach (var field in fields)
            {
                string fieldString = "                temp.{returnObjectFieldName} = reader.TryGetValue<{returnObjectFieldType}>(Fields.{tableName}.{returnObjectField});\n";
                fieldString = fieldString.Replace(RETURN_OBJECT_FIELD_NAME, field.returnObjectFieldName);
                fieldString = fieldString.Replace(RETURN_OBJECT_FIELD_TYPE, field.returnObjectFieldType);
                fieldString = fieldString.Replace(RETURN_OBJECT_FIELD, field.returnObjectField);
                method += fieldString;
            }

            // Add All subtype fields
            foreach (var subtype in subtypes)
            {
                string fieldString = "                temp.{subType_ParentFieldName} = {subtype_gettermethodName}({parameterName});\n";
                fieldString = fieldString.Replace(SUBTYPE_PARENT_FIELD_NAME, subtype.parentFieldName);
                fieldString = fieldString.Replace(SUBTYPE_GETTER_METHOD_NAME, subtype.gettermethodName);
                method += fieldString;
            }

            method +=
                "                {returnName} = temp;\n" +
                "            }\n" +
                "            reader.Close();\n" +
                "        }\n" +
                "    });\n" +
                "    return {returnName};\n" +
                "}";

            method = method.Replace(RETURN_TYPE, returnType);
            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(PARAMETER_TYPE, parameterType);
            method = method.Replace(PARAMETER_NAME, parameterName);
            method = method.Replace(RETURN_NAME, returnName);
            method = method.Replace(DEFAULT_VALUE, defaultValue);
            method = method.Replace(TABLE_NAME, tableName);
            method = method.Replace(FIELD_NAME, fieldName);

            return method;
        }

        public class AddObjectField
        {
            public string fieldName;
            public string returnObjectFieldName;
            public AddObjectField(string fieldName, string returnObjectFieldName)
            {
                this.fieldName = fieldName;
                this.returnObjectFieldName = returnObjectFieldName;
            }
        }
        public class AddObjectSubtype
        {
            public string parentFieldName;
            public string addermethodName;
            public AddObjectSubtype(string parentFieldName, string addermethodName)
            {
                this.parentFieldName = parentFieldName;
                this.addermethodName = addermethodName;
            }
        }

        public static string AddObject(string methodName, string parameterName, string parameterType, string tableName, AddObjectField[] fields, AddObjectSubtype[] subtypes)
        {
            // TODO: Should I change to return bool?
            string method =
                "public void {methodName}({parameterType} {parameterName})\n" +
                "{\n" +
                "    PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"INSERT INTO \" + Tables.{tableName} + \"(\" + Fields.Join(\n";

            // Add Field Names
            foreach (var field in fields)
            {
                string fieldString = "            Fields.{tableName}.{fieldName}\n";
                fieldString = fieldString.Replace(FIELD_NAME, field.fieldName);
                method += fieldString;
            }

            method += "        ) + \") VALUES(\" + FieldParams.Join(\n";

            // Add Field Parameters
            foreach (var fieldParam in fields)
            {
                string fieldParamString = "            FieldParams.{tableName}.{fieldName}\n";
                fieldParamString = fieldParamString.Replace(FIELD_NAME, fieldParam.fieldName);
                method += fieldParamString;
            }

            method +=
                "        ) + \")\";\n" +
                "\n";

            // Add Parameters Values
            foreach (var fieldParam in fields)
            {
                string paramString = "        command.Parameters.AddWithValue(FieldParams.{tableName}.{fieldName}, {parameterName}.{returnObjectFieldName});\n";
                paramString = paramString.Replace(FIELD_NAME, fieldParam.fieldName);
                paramString = paramString.Replace(RETURN_OBJECT_FIELD_NAME, fieldParam.returnObjectFieldName);
                method += paramString;
            }

            method +=
                "        command.ExecuteNonQuery();\n" +
                "\n";

            // Add All subtype fields
            foreach (var subtype in subtypes)
            {
                string fieldString = "                {subtype_addermethodName}(temp.{subType_ParentFieldName});\n";
                fieldString = fieldString.Replace(SUBTYPE_PARENT_FIELD_NAME, subtype.parentFieldName);
                fieldString = fieldString.Replace(SUBTYPE_ADDER_METHOD_NAME, subtype.addermethodName);
                method += fieldString;
            }
            method +=
                "    });\n" +
                "}";

            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(PARAMETER_NAME, parameterName);
            method = method.Replace(PARAMETER_TYPE, parameterType);
            method = method.Replace(TABLE_NAME, tableName);

            return method;
        }

        public class UpdateObjectField
        {
            public string fieldName;
            public string parameterFieldName;
            public UpdateObjectField(string fieldName, string parameterFieldName)
            {
                this.fieldName = fieldName;
                this.parameterFieldName = parameterFieldName;
            }
        }

        // TODO: Add events for these different methods

        // TODO: Maybe Add a param for public vs private this way we can specify subtypes as private

        // TODO: GetObjectWithParam GetNoteAttributes(long noteLuid)
        // TODO: UpdateObjectWithParam UpdateNoteAttributes(long noteLid, NoteAttributes)
        // TODO: GetAllOfFieldWithParam GetNoteResources(long noteLuid)

        // TODO: When updating, if the usn has changed, raise a conflict (maybe have a delegate to do this)
        // TODO: Return UpdateErrorCode (Conflict, Success, Unknown)
        // TODO: Version for checking USN
        public static string UpdateObject(string fieldName, string methodName, string parameterName, string parameterType, string parameterUniqueIdFieldName, string tableName, UpdateObjectField[] fields)
        {
            string method =
                "public bool {methodName}({parameterType} {parameterName})\n" +
                "{\n" +
                "    bool success = PerformOperation((conn, command) =>\n" +
                "    {\n" +
                "        command.CommandText = \"UPDATE \" + Tables.{tableName} + \" SET \" + Fields.Join(\n";

            foreach (var field in fields)
            {
                string fieldString = "            Fields.{tableName}.{fieldName}+\"=\"+FieldParams.{tableName}.{fieldName}\n";
                fieldString = fieldString.Replace(FIELD_NAME, field.fieldName);
                method += fieldString;
            }

            method +=
                "            ) + \") WHERE \" + Fields.{tableName}.{fieldName} + \"=\" + FieldParams.{tableName}.{fieldName};\n" +
                "\n";

            foreach (var field in fields)
            {
                string fieldString = "        command.Parameters.AddWithValue(FieldParams.{tableName}.{fieldName}, {parameterName}.{parameterFieldName});\n";;
                fieldString = fieldString.Replace(FIELD_NAME, field.fieldName);
                fieldString = fieldString.Replace(PARAMETER_FIELD_NAME, field.parameterFieldName);
                method += fieldString;
            }

            method +=
                "        command.Parameters.AddWithValue(FieldParams.{tableName}.{fieldName}, {parameterName}.{parameterUniqueIdFieldName});\n" + 
                "\n" +
                "        command.ExecuteNonQuery();\n" +
                "    });\n" +
                "    return success;\n" +
                "}";

            method = method.Replace(FIELD_NAME, fieldName);
            method = method.Replace(METHOD_NAME, methodName);
            method = method.Replace(PARAMETER_NAME, parameterName);
            method = method.Replace(PARAMETER_TYPE, parameterType);
            method = method.Replace(PARAMETER_UNIQUE_ID_FIELD_NAME, parameterUniqueIdFieldName);
            method = method.Replace(TABLE_NAME, tableName);

            return method;
        }

        #region Constants
        static string RETURN_TYPE = "{returnType}";
        static string METHOD_NAME = "{methodName}";
        static string RETURN_NAME = "{returnName}";
        static string RETURN_OBJECT_FIELD = "{returnObjectField}";
        static string FIELD_NAME = "{fieldName}";
        static string TABLE_NAME = "{tableName}";
        static string PARAMETER_TYPE = "{parameterType}";
        static string DEFAULT_VALUE = "{defaultValue}";
//        static string INPUT_FIELD_NAME = "{inputFieldName}";
        static string PARAMETER_NAME = "{parameterName}";
        static string CAST_TYPE = "{castType}";
        static string RETURN_OBJECT_FIELD_NAME = "{returnObjectFieldName}";
        static string RETURN_OBJECT_FIELD_TYPE = "{returnObjectFieldType}";
        static string SUBTYPE_PARENT_FIELD_NAME = "{subType_ParentFieldName}";
        static string SUBTYPE_GETTER_METHOD_NAME = "{subtype_gettermethodName}";
        static string SUBTYPE_ADDER_METHOD_NAME = "{subtype_addermethodName}";
        static string PARAMETER_UNIQUE_ID_FIELD_NAME = "{parameterUniqueIdFieldName}";
        static string PARAMETER_FIELD_NAME = "{parameterFieldName}";
        #endregion
    }
}

