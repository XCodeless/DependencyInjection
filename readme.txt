��Ŀ�ṹ:

samples : ���������ļ���
src: ���Դ���ļ���
test/benchmark : ���ܲ����ļ���
test/ut : ��Ԫ�����ļ���
solution items: ȫ�������ļ���, ��Ҫ��������ļ�.

�������깤��ʱ��Ҫ�ֶ�������Ŀ����.




Directory.Build.props �ļ�:

���÷�Χ: src �ļ����µ���Ŀ;

����˵��:

	1. ���������:
		a. TargetFrameworks : ����ʱ/��׼����ݰ汾��ǩ, ָ���� src ����Ŀ�����ݵĿ��, �����Ҫ���ƻ�,���Ƴ��ñ�ǩ,���� src �µ���Ŀ�����ļ����Զ�����Ŀ��.
		b. Nullable : �ɿ����ñ�ǩ, �ñ�ǩĬ�Ͽ���, �������Ͻ���̵ĺ�ϰ��.
		c. LangVersion : ���԰汾��ǩ,Ĭ��ʹ��Ԥ����.

	2. �����Ϣ����:
		a. IsPackable �Ƿ����������.
		b. IncludeSymbols �Ƿ����Ԫ���ݷ��ŵ�.
		c. GeneratePackageOnBuild �Ƿ�����Ŀ����ʱ������Ŀ��.
		d. PackageRequireLicenseAcceptance �Ƿ���Ҫ�������֤.
		e. PackageProjectUrl ��Ŀ���ӵ�ַ.
		f. Copyright ���߼������ߵȰ�Ȩ˵��.
		g. Company �ð���������
		h. Authors �����ǳ�/����
		i. PackageIcon �ϴ��� NUGET ʱ,�����õ�ͷ��. ������[��Դ��]���ӹ���.
		j. PackageLicenseFile �ϴ��� NUGET ʱ,�������������֤�ļ�, ������[��Դ��]���ӹ���.

	3. ��Դ�����:
		a. ��һ��: {myImage} ��Ҫ�滻�� resource �ļ�����������ŵ�,��������ϴ���ͼƬ�ļ�.
		b. ��һ��: {nuget pack image} ��Ҫ�滻��[�����Ϣ��]������ָ����Ҫ�ϴ��� PackageIcon �ڵ�ֵ. ���ֶ�����������������Դ�ļ�.
		c. �ڶ���: {myLicense} �ο� a.b ����, ԭ����ͬ.




Project �����ļ�:

����˵��:
	
	1. PackageId : nuget ������.
	2. PackageReleaseNotes : nuget ��������Ϣ.
	3. PackageTags : nuget �����ؼ���.
	4. Description : nuget ��Ŀ������Ϣ.
	5. Version : nuget ���汾��Ϣ.
	6. FileVersion : nuget �ļ��汾��Ϣ.
	7. AssemblyVersion : nuget ���ɳ��򼯵İ汾��Ϣ.




publish yml �ļ�:

���ļ�Ϊ GITHUB �ܵ��еķ�����������. ��������� Main ��֧��. 
����˵��:

	Push to Nuget - Project �ڵ�: ${{ secrets.NUGET_KEY }} Ϊ GITHUB ���������д洢�ķ��� NUGET ����Ҫ�� KEY.




test.yml �ļ�:

���ļ�Ϊ GITHUB �ܵ��еĲ�����������. ��������� test ��֧��. 
����˵��:

	��һ�� : {myProject} �޸�Ϊ�Լ���Ŀ������.
	Upload to Codecov �ڵ�: ${{ secrets.COVERAGE_KEY }} Ϊ ���͵� ���Ը����� ��վ����Ҫ�� KEY.


